using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repertoire
{    
    class IngredientRepertoire : IIngredientRepertoire
    {
        private readonly IDbSession _session;
        public IngredientRepertoire(IDbSession session)
        {
            _session = session;
        }


        public async Task<ReponsePagination<Ingredient>> GetAllAsync(RequetePagination requetePagination)
        {
            var requete = @"SELECT * FROM Ingredient
                            ORDER BY IdIngredient
                            OFFSET @TaillePage * (@Page - 1) rows
                            FETCH NEXT @TaillePage rows only";
            string requeteNbIngredient = "SELECT COUNT(*) FROM Ingredient";

            List<Ingredient> ingredients = await _session.Connection.QueryAsync<Ingredient>(requete, requetePagination, _session.Transaction) as List<Ingredient>;
            int nbIngredient = await _session.Connection.ExecuteScalarAsync<int>(requeteNbIngredient, null, _session.Transaction);

            return new ReponsePagination<Ingredient>(requetePagination.Page, requetePagination.TaillePage, nbIngredient, ingredients);
        }

        public async Task<Ingredient> GetAsync(int id)
        {
            var requete = @"SELECT * FROM Ingredient WHERE IdIngredient = @ID";

            return await _session.Connection.QueryFirstOrDefaultAsync<Ingredient>(requete, param: new { ID = id }, _session.Transaction);
        }
    }
}
