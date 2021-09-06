using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using ClientMobile.VueModeles;
using ClientMobile.VMDatas;

namespace ClientMobile.Vues
{
    /// <summary>
    /// Page des menus du service
    /// </summary>
    public sealed partial class ListeMenusPage : Page
    {
        private readonly ListeMenusVueModele _listeMenusVueModele = new ListeMenusVueModele();

        public ListeMenusPage()
        {
            this.InitializeComponent();            
        }

        /// <summary>
        /// Click sur la liste des menus
        /// Sélection d'un menu précis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvListeMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (lvListeMenu.SelectedItem != null)
            {
                _listeMenusVueModele.MenuSelected = (MenuService)lvListeMenu.SelectedItem; //Menu précis
                Frame.Navigate(typeof(ReservationPage));
            }            
        }
    }
}
