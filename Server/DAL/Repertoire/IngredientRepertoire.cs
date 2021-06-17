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
            throw new NotImplementedException();
        }

        public async Task<Ingredient> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
