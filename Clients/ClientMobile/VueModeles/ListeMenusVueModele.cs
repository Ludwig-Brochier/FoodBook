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

        private readonly MenuModele _menuModele = MenuModele.GetInstance;
        private List<Menu> menus = new List<Menu>();
        public List<MenuService> menusService = new List<MenuService>();

        public ListeMenusVueModele()
        {
            menus = _menuModele.menus;
            StructurerService(menus);
        }

        private void StructurerService(List<Menu> oldService)
        {
            foreach (Menu menu in oldService)
            {
                //MenuService newMenu = new MenuService();
                //newMenu.id = (int)menu.IdMenu;
                //newMenu.dteMenu = menu.DteMenu;
                //newMenu.midiSoir = menu.ServiceMidi ? "Midi" : "Soir";
                //List<Plat> plats = menu.Plats;
                //foreach (Plat plat in plats)
                //{
                //    if (plat.TypePlat == "Entrée")
                //    {
                //        newMenu.entree = plat.Intitule;
                //    }

                //    else if (plat.TypePlat == "Plat")
                //    {
                //        newMenu.plat = plat.Intitule;
                //    }

                //    else
                //    {
                //        newMenu.dessert = plat.Intitule;
                //    }
                //}

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
