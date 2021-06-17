using System.Threading.Tasks;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;

namespace BLL.Services
{
    public interface IRestaurationService
    {
        #region Ingredient
        /// <summary>
        /// Permet de récupérer tous les ingrédients selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <returns>Les ingrédients mis en page</returns>
        Task<ReponsePagination<Ingredient>> GetAllIngredientsAsync(RequetePagination requetePagination);

        /// <summary>
        /// Permet de récupérer un ingrédient précis via son ID
        /// </summary>
        /// <param name="idIngredient">L'identifiant de l'ingrédient</param>
        /// <returns>L'ingrédient demandé</returns>
        Task<Ingredient> GetIngredientAsync(int idIngredient);
        #endregion

        #region Plat
        /// <summary>
        /// Permet de récupérer tous les plats selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <returns>Les plats mis en page</returns>
        Task<ReponsePagination<Plat>> GetAllPlatsAsync(RequetePagination requetePagination);

        /// <summary>
        /// Permet de récupérer un plat précis via son ID
        /// </summary>
        /// <param name="idPlat">L'identifiant du plat</param>
        /// <returns>Le plat demandé</returns>
        Task<Plat> GetPlatAsync(int idPlat);

        /// <summary>
        /// Permet d'ajouter un plat
        /// </summary>
        /// <param name="plat">Le plat à ajouter</param>
        /// <returns>Le plat ajouté</returns>
        Task<Plat> InsertPlatAsync(Plat plat);

        /// <summary>
        /// Permet de mettre à jour un plat
        /// </summary>
        /// <param name="plat">Les données du plat</param>
        /// <returns>Le plat mis à jour</returns>
        Task<Plat> UpdatePlatAsync(Plat plat);

        /// <summary>
        /// Permet de supprimer un plat précis via son ID
        /// </summary>
        /// <param name="idPlat">L'identifiant du plat</param>
        /// <returns>Si oui ou non le plat est supprimé</returns>
        Task<bool> DeletePlatAsync(int idPlat);
        #endregion

        #region Menu
        /// <summary>
        /// Permet de récupérer tous les menus d'une semaine précise selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination précise</param>
        /// <param name="idSemaine">L'identifiant de la semaine précise</param>
        /// <returns>Les menus de la semaine mis en page</returns>
        Task<ReponsePagination<Menu>> GetAllMenusAsync(RequetePagination requetePagination, int idSemaine);

        /// <summary>
        /// Permet de récupérer un menu précis via son ID
        /// </summary>
        /// <param name="idMenu">L'identifiant du menu</param>
        /// <returns>Le menu demandé</returns>
        Task<Menu> GetMenuAsync(int idMenu);

        /// <summary>
        /// Permet d'ajouter un menu
        /// </summary>
        /// <param name="menu">Le menu à ajouter</param>
        /// <returns>Le menu ajouté</returns>
        Task<Menu> InsertMenuAsync(Menu menu);

        /// <summary>
        /// Permet de mettre à jour un menu
        /// </summary>
        /// <param name="menu">Les données du menu</param>
        /// <returns>Le menu mis à jour</returns>
        Task<Menu> UpdateMenuAsync(Menu menu);

        /// <summary>
        /// Permet de supprimer un menu précis via son ID
        /// </summary>
        /// <param name="idMenu">L'identifiant du menu</param>
        /// <returns>Si oui ou non le menu est supprimé</returns>
        Task<bool> DeleteMenuAsync(int idMenu);
        #endregion
    }
}
