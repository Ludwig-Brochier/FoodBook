using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using DAL.Repertoire;
using System.Threading.Tasks;
using BO.DTO.Modeles;
using System;

namespace BLL.Services
{
    class RestaurationService : IRestaurationService
    {
        private readonly IUnitOfWork _bdd;
        public RestaurationService(IUnitOfWork unitOfWork)
        {
            _bdd = unitOfWork;
        }

        #region Ingredient
        public async Task<ReponsePagination<Ingredient>> GetAllIngredientsAsync(RequetePagination requetePagination)
        {
            IIngredientRepertoire ingredient = _bdd.GetRepertoire<IIngredientRepertoire>();
            return await ingredient.GetAllAsync(requetePagination);
        }

        public async Task<Ingredient> GetIngredientAsync(int idIngredient)
        {
            IIngredientRepertoire ingredientRepertoire = _bdd.GetRepertoire<IIngredientRepertoire>();
            return await ingredientRepertoire.GetAsync(idIngredient);
        }
        #endregion

        #region Plat
        public async Task<ReponsePagination<Plat>> GetAllPlatsAsync(RequeteFiltresPlats requeteFiltresPlats)
        {
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();

            if (requeteFiltresPlats.Type != null)
            {
                if (requeteFiltresPlats.Type == "entree" || requeteFiltresPlats.Type == "plat" || requeteFiltresPlats.Type == "dessert")
                {
                    return await platRepertoire.GetAllPlatsAsync(requeteFiltresPlats);
                }

                else
                {
                    return null;
                }
            }
            
            return await platRepertoire.GetAllPlatsAsync(requeteFiltresPlats);
        }

        public async Task<ReponsePagination<PlatPopulaire>> GetAllPlatsPopulaireAsync(RequeteFiltresPlats requeteFiltresPlats)
        {
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
            return await platRepertoire.GetAllPlatsPopulaireAsync(requeteFiltresPlats);
        }

        public async Task<Plat> GetPlatAsync(int idPlat)
        {
            IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
            return await platRepertoire.GetAsync(idPlat);
        }

        public async Task<Plat> InsertPlatAsync(Plat plat)
        {            
            if (plat.PlatIngredients != null && plat.Intitule != string.Empty && plat.Prix != 0)
            {
                if (plat.TypePlat == "Entrée" || plat.TypePlat == "Plat" || plat.TypePlat == "Dessert")
                {
                    _bdd.DebutTransaction();
                    IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
                    Plat newPlat = await platRepertoire.InsertAsync(plat);
                    _bdd.Commit();
                    return newPlat;
                }
            }

            return null;
        }

        public async Task<Plat> UpdatePlatAsync(Plat plat)
        {
            if (plat.Intitule != string.Empty && plat.Prix != 0)
            {
                if (plat.TypePlat == "Entrée" || plat.TypePlat == "Plat" || plat.TypePlat == "Dessert")
                {
                    _bdd.DebutTransaction();
                    IPlatRepertoire platRepertoire = _bdd.GetRepertoire<IPlatRepertoire>();
                    Plat newPlat = await platRepertoire.UpdateAsync(plat);
                    _bdd.Commit();
                    return newPlat;
                }
            }

            return null;
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
        #endregion

        #region Menu
        public async Task<ReponsePeriodique<Menu>> GetAllMenusAsync(RequetePeriodique requetePeriodique)
        {
            if (requetePeriodique.Fin >= requetePeriodique.Debut)
            {
                IMenuRepertoire menuRepertoire = _bdd.GetRepertoire<IMenuRepertoire>();
                return await menuRepertoire.GetAllPeriodeAsync(requetePeriodique);
            }

            else
            {
                return null;
            }
        }

        public async Task<Menu> GetMenuAsync(int idMenu)
        {
            IMenuRepertoire menuRepertoire = _bdd.GetRepertoire<IMenuRepertoire>();
            return await menuRepertoire.GetAsync(idMenu);
        }

        public async Task<Menu> InsertMenuAsync(Menu menu)
        {
            int hasDate = DateTime.Compare(menu.DteMenu, new DateTime(0001, 1, 1, 0, 0, 0));
            bool hasEntree = false;
            bool hasPlat = false;
            bool hasDessert = false;

            if (hasDate != 0)
            {
                if (menu.Plats.Count == 3)
                {
                    foreach (Plat plat in menu.Plats)
                    {
                        if (plat.TypePlat == "Entrée")
                        {
                            hasEntree = true;
                        }

                        else if (plat.TypePlat == "Plat")
                        {
                            hasPlat = true;
                        }

                        else if (plat.TypePlat == "Dessert")
                        {
                            hasDessert = true;
                        }

                        else
                        {
                            return null;
                        }
                    }

                    if (hasEntree == true && hasPlat == true && hasDessert == true)
                    {
                        _bdd.DebutTransaction();
                        IMenuRepertoire menuRepertoire = _bdd.GetRepertoire<IMenuRepertoire>();
                        Menu newMenu = await menuRepertoire.InsertAsync(menu);
                        _bdd.Commit();
                        return newMenu;
                    }
                }
            }

            return null;
        }

        public async Task<Menu> UpdateMenuAsync(Menu menu)
        {
            int hasDate = DateTime.Compare(menu.DteMenu, new DateTime(0001, 1, 1, 0, 0, 0));
            bool hasEntree = false;
            bool hasPlat = false;
            bool hasDessert = false;

            if (hasDate != 0)
            {
                _bdd.DebutTransaction();
                IMenuRepertoire menuRepertoire = _bdd.GetRepertoire<IMenuRepertoire>();

                if (menu.Plats == null)
                {
                    Menu newMenu = await menuRepertoire.UpdateAsync(menu);
                    _bdd.Commit();
                    return newMenu;
                }

                if (menu.Plats.Count == 3)
                {
                    foreach (Plat plat in menu.Plats)
                    {
                        if (plat.TypePlat == "Entrée")
                        {
                            hasEntree = true;
                        }

                        else if (plat.TypePlat == "Plat")
                        {
                            hasPlat = true;
                        }

                        else if (plat.TypePlat == "Dessert")
                        {
                            hasDessert = true;
                        }

                        else
                        {
                            return null;
                        }
                    }

                    if (hasEntree == true && hasPlat == true && hasDessert == true)
                    {
                        Menu newMenu = await menuRepertoire.UpdateAsync(menu);
                        _bdd.Commit();
                        return newMenu;
                    }
                }
            }
            return null;
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
        #endregion
    }
}
