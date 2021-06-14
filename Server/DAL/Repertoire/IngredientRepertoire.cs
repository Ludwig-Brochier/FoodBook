using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
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
            List<Ingredient> ingredients = new()
            {
                new Ingredient(1, "pain", 0.25),
                new Ingredient(2, "fromage", 0.35),
                new Ingredient(3, "jambon", 0.55)
            };

            return new ReponsePagination<Ingredient>(requetePagination.Page, requetePagination.TaillePage, 3, ingredients);
        }

        public async Task<Ingredient> GetAsync(int id)
        {
            return new Ingredient(1, "pain", 0.25);
        }
    }
}
