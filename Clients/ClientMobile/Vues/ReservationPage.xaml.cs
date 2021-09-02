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

namespace ClientMobile.Vues
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ReservationPage : Page
    {
        private readonly ReservationVueModele reservationVueModele = new ReservationVueModele();

        public ReservationPage()
        {
            this.InitializeComponent();
        }

        private void Logo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        
        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListeMenusPage));
        }

        private void btnReserver_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
