using ClientMobile.Modeles;
using System.Threading.Tasks;

namespace ClientMobile.VueModeles
{
    /// <summary>
    /// Vue Modele de la page d'accueil
    /// </summary>
    public class MainVueModele :  VueModelesBase
    {
        private MenuModele _menuModele = MenuModele.Instance; //Instance du Singleton

        private bool _isLoading = true;
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        /// <summary>
        /// Chargement de la liste des menus du service
        /// </summary>
        /// <returns></returns>
        public async Task Chargement()
        {
            IsLoading = true;
            await _menuModele.SetListMenu();
            IsLoading = false;
        }
    }
}
