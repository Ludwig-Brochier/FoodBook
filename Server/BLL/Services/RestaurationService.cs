using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using DAL.Repertoire;
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

        public async Task<bool> DeletePlatAsync(int idPlat)
        {
            _bdd.DebutTransaction();
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
            bool delete = await platRepertoire.DeleteAsync(idPlat);
            if (delete)
            {
                _bdd.Commit();
                return true;
            }

            else
            {
                _bdd.Rollback();
                return false;
            }
        }

        public async Task<ReponsePagination<Ingredient>> GetAllIngredientsAsync(RequetePagination requetePagination)
        {
            IIngredientRepertoire ingredient = _bdd.GetRepertoire<IIngredientRepertoire>();
            return await ingredient.GetAllAsync(requetePagination);
        }

        public Task<ReponsePeriodique<Menu>> GetAllMenusAsync(RequetePeriodique requetePeriodique)
        {
            throw new NotImplementedException();
        }

        public async Task<ReponsePagination<Plat>> GetAllPlatsAsync(RequetePagination requetePagination)
        {
            IPlatRepertoire plat = _bdd.GetRepertoire<IPlatRepertoire>();
            return await plat.GetAllAsync(requetePagination);
        }

        public async Task<Ingredient> GetIngredientAsync(int idIngredient)
        {
            IIngredientRepertoire ingredientRepertoire = _bdd.GetRepertoire<IIngredientRepertoire>();
            return await ingredientRepertoire.GetAsync(idIngredient);
        }

        public Task<Menu> GetMenuAsync(int idMenu)
        {
            throw new NotImplementedException();
        }

        public async Task<Plat> GetPlatAsync(int idPlat)
        {
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
            return await platRepertoire.GetAsync(idPlat);
        }

        public Task<Menu> InsertMenuAsync(Menu menu)
        {
            throw new NotImplementedException();
        }

        public async Task<Plat> InsertPlatAsync(Plat plat)
        {
            _bdd.DebutTransaction();
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
            Plat newPlat = await platRepertoire.InsertAsync(plat);
            _bdd.Commit();
            return newPlat;
        }

        public Task<Menu> UpdateMenuAsync(Menu menu)
        {
            throw new NotImplementedException();
        }

        public async Task<Plat> UpdatePlatAsync(Plat plat)
        {
            _bdd.DebutTransaction();
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
            Plat newPlat = await platRepertoire.UpdateAsync(plat);
            _bdd.Commit();
            return newPlat;
        }
    }
}
