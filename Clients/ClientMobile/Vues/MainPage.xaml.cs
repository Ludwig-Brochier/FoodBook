using Windows.UI.Xaml.Controls;
using ClientMobile.VueModeles;

namespace ClientMobile.Vues
{
    /// <summary>
    /// Page d'accueil de l'application mobile
    /// Ecran de chargement puis navigation vers la page des menus du service
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly MainVueModele _mainVueModele = new MainVueModele();

        public MainPage()
        {
            this.InitializeComponent();
            _mainVueModele.PropertyChanged += VM_PropertyChanged;
            _mainVueModele.Chargement();
        }

        private void VM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName =="IsLoading" && !_mainVueModele.IsLoading)
            {
                Frame.Navigate(typeof(ListeMenusPage));
            }
        }
    }
}
