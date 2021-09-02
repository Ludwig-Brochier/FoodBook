﻿using System;
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


namespace ClientMobile.Vues
{
    public sealed partial class MainPage : Page
    {        
        public MainPage()
        {
            this.InitializeComponent();
            Load();
        }

        private async void Load()
        {
            await Loader();
        }

        private async Task Loader()
        {
            LoadingControl.IsLoading = true;
            await Task.Delay(3000);

            Frame.Navigate(typeof(ListeMenusPage));
        }
    }
}