using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using ClientMobile.VueModeles;

namespace ClientMobile.Vues
{
    /// <summary>
    /// Page de réservation d'un menu
    /// </summary>
    public sealed partial class ReservationPage : Page
    {
        private readonly ReservationVueModele _reservationVueModele = new ReservationVueModele();

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

        private async void btnReserver_Click(object sender, RoutedEventArgs e)
        {
            await _reservationVueModele.ReserverMenu();
        }

        private void btnFermerPopUp_Click(object sender, RoutedEventArgs e)
        {
            _reservationVueModele.PopUp = false;
        }
    }
}
