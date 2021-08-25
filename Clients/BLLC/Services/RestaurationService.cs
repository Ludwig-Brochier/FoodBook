using BO.DTO.Modeles;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLLC.Services
{
    public class RestaurationService : IRestaurationService
    {
        private readonly HttpClient _httpClient;
        public RestaurationService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        #region Ingredient
        public Task<ReponsePagination<Ingredient>> GetAllIngredientsAsync(RequetePagination requetePagination)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetIngredientAsync(int idIngredient)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Plat
        public Task<ReponsePagination<Plat>> GetAllPlatsAsync(RequeteFiltresPlats requeteFiltresPlats)
        {
            throw new NotImplementedException();
        }

        public Task<ReponsePagination<PlatPopulaire>> GetAllPlatsPopulaireAsync(RequeteFiltresPlats requeteFiltresPlats)
        {
            throw new NotImplementedException();
        }

        public Task<Plat> GetPlatAsync(int idPlat)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> InsertMenuAsync(Menu menu)
        {
            throw new NotImplementedException();
        }

        public Task<Plat> UpdatePlatAsync(Plat plat)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlatAsync(int idPlat)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Menu
        public Task<ReponsePeriodique<Menu>> GetAllMenusAsync(RequetePeriodique requetePeriodique)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> GetMenuAsync(int idMenu)
        {
            throw new NotImplementedException();
        }

        public Task<Plat> InsertPlatAsync(Plat plat)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> UpdateMenuAsync(Menu menu)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMenuAsync(int idMenu)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
