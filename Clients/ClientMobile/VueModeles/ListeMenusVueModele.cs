using System.Collections.Generic;
using System.Threading.Tasks;
using ClientMobile.Modeles;
using BO.Entite;
using ClientMobile.VMDatas;

namespace ClientMobile.VueModeles
{
    /// <summary>
    /// Vue Modele de la page des menus du service
    /// </summary>
    public class ListeMenusVueModele : VueModelesBase
    {
        private readonly ReservationModel _reservationModel = ReservationModel.Instance; //Instance du Singleton
        private readonly MenuModele _menuModele = MenuModele.Instance; //Instance du Singleton
        private List<Menu> menus = new List<Menu>();
        public List<MenuService> menusService = new List<MenuService>();

        public ListeMenusVueModele()
        {
            StructurerService();
        }

        /// <summary>
        /// Transforme les menus en menus service
        /// </summary>
        /// <returns></returns>
        private async Task StructurerService()
        {
            menus = _menuModele.menus;
            foreach (Menu menu in menus)
            {
                menusService.Add(MenuService.FromMenu(menu));
            }
        }

        /// <summary>
        /// Récupère le menu sélectionné
        /// </summary>
        private MenuService _menuSelected;
        public MenuService MenuSelected
        {
            get => _menuSelected;
            set
            {
                Set(ref _menuSelected, value);
                _reservationModel.Menu = menus.Find(m => _menuSelected.id == m.IdMenu);
            }
        }
    }
}
