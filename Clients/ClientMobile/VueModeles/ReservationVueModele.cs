using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientMobile.Modeles;
using ClientMobile.VMDatas;
using ClientMobile.Vues;

namespace ClientMobile.VueModeles
{
    public class ReservationVueModele : VueModelesBase
    {
        private readonly ListeMenusPage listeMenusPage = new ListeMenusPage();
     

        public ReservationVueModele()
        {
            Menu = MenuService.FromMenu(ReservationModel.Instance.Menu);
            ReservationModel.Instance.PropertyChanged += Instance_PropertyChanged;

           
        }

        private void Instance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Menu")
            {
                Menu = MenuService.FromMenu(ReservationModel.Instance.Menu);
            }
        }


        private MenuService _menu;
        public MenuService Menu
        {
            get => _menu;
            set => Set(ref _menu, value);
        }
    }
}
