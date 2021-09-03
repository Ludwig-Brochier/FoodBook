using ClientMobile.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMobile.VueModeles
{
    class MainVueModele :  VueModelesBase
    {

        private MenuModele _menuModele = MenuModele.GetInstance; 


        private bool _isLoading = true;
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        public async Task Chargement()
        {
            IsLoading = true;
            await _menuModele.SetListMenu();
            IsLoading = false;
        }
    }
}
