using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientMobile.Modeles;
using BO.Entite;
using ClientMobile.VMDatas;

namespace ClientMobile.VueModeles
{


    public class ListeMenusVueModele : VueModelesBase
    {
        private readonly ReservationModel _reservationModel = ReservationModel.Instance;

        private readonly MenuModele _menuModele = MenuModele.Instance;
        private List<Menu> menus = new List<Menu>();
        public List<MenuService> menusService = new List<MenuService>();

        public ListeMenusVueModele()
        {
            StructurerService();
        }

        private async Task StructurerService()
        {
            menus = _menuModele.menus;
            foreach (Menu menu in menus)
            {
                menusService.Add(MenuService.FromMenu(menu));
            }
        }


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
