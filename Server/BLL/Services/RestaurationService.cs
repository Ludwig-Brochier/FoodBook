using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class RestaurationService : IRestaurationService
    {
        private readonly IUnitOfWork _bdd;
        public RestaurationService(IUnitOfWork unitOfWork)
        {
            _bdd = unitOfWork;
        }


        public Task<bool> DeleteMenuAsync(int idMenu)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlatAsync(int idPlat)
        {
            throw new NotImplementedException();
        }

        public Task<ReponsePagination<Ingredient>> GetAllIngredientsAsync(RequetePagination requetePagination)
        {
            throw new NotImplementedException();
        }

        public Task<ReponsePeriodique<Menu>> GetAllMenusAsync(RequetePeriodique requetePeriodique)
        {
            throw new NotImplementedException();
        }

        public Task<ReponsePagination<Plat>> GetAllPlatsAsync(RequetePagination requetePagination)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetIngredientAsync(int idIngredient)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> GetMenuAsync(int idMenu)
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

        public Task<Plat> InsertPlatAsync(Plat plat)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> UpdateMenuAsync(Menu menu)
        {
            throw new NotImplementedException();
        }

        public Task<Plat> UpdatePlatAsync(Plat plat)
        {
            throw new NotImplementedException();
        }
    }
}
