using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ClientMobile.VueModeles;
using ClientMobile.VMDatas;

namespace ClientMobile.Vues
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ListeMenusPage : Page
    {
        private readonly ListeMenusVueModele listeMenusVueModele = new ListeMenusVueModele();

        public ListeMenusPage()
        {
            this.InitializeComponent();            
        }

        private void lvListeMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (lvListeMenu.SelectedItem != null)
            {
                listeMenusVueModele.MenuSelected = (MenuService)lvListeMenu.SelectedItem;
                Frame.Navigate(typeof(ReservationPage));
            }            
        }
    }
}
