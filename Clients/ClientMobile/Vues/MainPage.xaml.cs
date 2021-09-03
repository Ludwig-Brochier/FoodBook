using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ClientMobile.Modeles;
using ClientMobile.VueModeles;

namespace ClientMobile.Vues
{
    public sealed partial class MainPage : Page
    {
        private MainVueModele VM = new MainVueModele();

        public MainPage()
        {
            this.InitializeComponent();
            VM.PropertyChanged += VM_PropertyChanged;
            VM.Chargement();
        }

        private void VM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName =="IsLoading" && !VM.IsLoading)
            {
                Frame.Navigate(typeof(ListeMenusPage));
            }
        }
    }
}
