using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using DAL.Repertoire;
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


        public async Task<bool> DeleteMenuAsync(int idMenu)
        {
            _bdd.DebutTransaction();
            IMenuRepertoire menuRepertoire = _bdd.GetRepertoire<IMenuRepertoire>();
            bool delete = await menuRepertoire.DeleteAsync(idMenu);
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

        public async Task<ReponsePeriodique<Menu>> GetAllMenusAsync(RequetePeriodique requetePeriodique)
        {
            IMenuRepertoire menuRepertoire = _bdd.GetRepertoire<IMenuRepertoire>();
            return await menuRepertoire.GetAllPeriodeAsync(requetePeriodique);
        }

        public async Task<ReponsePagination<Plat>> GetAllPlatsAsync(RequetePagination requetePagination)
        {
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
            return await platRepertoire.GetAllAsync(requetePagination);
        }

        public async Task<Ingredient> GetIngredientAsync(int idIngredient)
        {
            IIngredientRepertoire ingredientRepertoire = _bdd.GetRepertoire<IIngredientRepertoire>();
            return await ingredientRepertoire.GetAsync(idIngredient);
        }

        public async Task<Menu> GetMenuAsync(int idMenu)
        {
            IMenuRepertoire menuRepertoire = _bdd.GetRepertoire<IMenuRepertoire>();
            return await menuRepertoire.GetAsync(idMenu);
        }

        public async Task<Plat> GetPlatAsync(int idPlat)
        {
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
            return await platRepertoire.GetAsync(idPlat);
        }

        public async Task<Menu> InsertMenuAsync(Menu menu)
        {
            _bdd.DebutTransaction();
            IMenuRepertoire menuRepertoire = _bdd.GetRepertoire<IMenuRepertoire>();
            Menu newMenu = await menuRepertoire.InsertAsync(menu);
            _bdd.Commit();
            return newMenu;
        }

        public async Task<Plat> InsertPlatAsync(Plat plat)
        {
            _bdd.DebutTransaction();
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
            Plat newPlat = await platRepertoire.InsertAsync(plat);
            _bdd.Commit();
            return newPlat;
        }

        public async Task<Menu> UpdateMenuAsync(Menu menu)
        {
            _bdd.DebutTransaction();
            IMenuRepertoire menuRepertoire = _bdd.GetRepertoire<IMenuRepertoire>();
            Menu newMenu = await menuRepertoire.UpdateAsync(menu);
            _bdd.Commit();
            return newMenu;
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
