using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var requeteTask = @"select * from Ingredient
                            ORDER BY IdIngredient
                            OFFSET @TaillePage * (@Page - 1) rows
                            FETCH NEXT @TaillePage rows only";
            string requeteNbIngredient = "select count(*) from Ingredient";

            IEnumerable<Ingredient> taskIngredient = await _session.Connection.QueryAsync<Ingredient>(requeteTask, requetePagination, _session.Transaction);
            int nbIngredient = await _session.Connection.ExecuteScalarAsync<int>(requeteNbIngredient, null, _session.Transaction);

            return new ReponsePagination<Ingredient>(requetePagination.Page, requetePagination.TaillePage, nbIngredient, taskIngredient.ToList());
        }

        public async Task<Ingredient> GetAsync(int id)
        {
            var requete = @"select * from Ingredient where IdIngredient = @ID";

            return await _session.Connection.QueryFirstOrDefaultAsync<Ingredient>(requete, param: new { ID = id }, _session.Transaction);
        }
    }
}
