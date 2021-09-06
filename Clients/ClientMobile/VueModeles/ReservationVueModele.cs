using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Entite;
using ClientMobile.Modeles;
using ClientMobile.VMDatas;
using ClientMobile.Vues;

namespace ClientMobile.VueModeles
{
    public class ReservationVueModele : VueModelesBase
    {
        private readonly ReservationModel _reservationModel = ReservationModel.Instance;
        private readonly ListeMenusPage listeMenusPage = new ListeMenusPage();        

        public ReservationVueModele()
        {
            Menu = MenuService.FromMenu(ReservationModel.Instance.Menu);
            _reservationModel.PropertyChanged += Instance_PropertyChanged;
        }

        private void Instance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Menu")
            {
                Menu = MenuService.FromMenu(_reservationModel.Menu);
            }
        }


        private MenuService _menu;
        public MenuService Menu
        {
            get => _menu;
            set => Set(ref _menu, value);
        }

        private string _nom;
        public string Nom
        {
            get => _nom;
            set => Set(ref _nom, value);
        }

        private string _prenom;
        public string Prenom
        {
            get => _prenom;
            set => Set(ref _prenom, value);
        }

        private string _numTel;
        public string NumTel
        {
            get => _numTel;
            set => Set(ref _numTel, value);
        }

        private int _nbParticipants;
        public int NbParticipants
        {
            get => _nbParticipants;
            set => Set(ref _nbParticipants, value);
        }

        private string _formuleResa;
        public string FormuleResa
        {
            get => _formuleResa;
            set => Set(ref _formuleResa, value);
        }

        private bool _popUp = false;
        public bool PopUp
        {
            get => _popUp;
            set => Set(ref _popUp, value);
        }

        private string _messagePopUpResa = "";
        public string MessagePopUpResa
        {
            get => _messagePopUpResa;
            set => Set(ref _messagePopUpResa, value);
        }

        public async Task CommandReserver()
        {
            if (Nom != string.Empty && Prenom != string.Empty && NumTel != string.Empty && NbParticipants >= 1 && NbParticipants <= 9 && FormuleResa != string.Empty)
            {
                _reservationModel.Nom = Nom;
                _reservationModel.Prenom = Prenom;
                _reservationModel.NumTel = NumTel;
                _reservationModel.NbParticipants = NbParticipants;
                _reservationModel.FormuleResa = GetFormule(FormuleResa);

                Reservation reservation = await _reservationModel.AjoutReservation();

                MessagePopUpResa = reservation.IdReservation != null ? "Votre réservation est prise en compte." : "Une erreur est survenue.";

                PopUp = true;
            }

            else
            {
                MessagePopUpResa = "Veuillez remplir tous les champs.";
                PopUp = true;
            }
        }

        private Formule GetFormule(string intitule)
        {
            switch (intitule)
            {
                case "Entrée":
                    return new Formule(1, "Entrée");
                case "Plat":
                    return new Formule(2, "Plat");
                case "Dessert":
                    return new Formule(3, "Dessert");
                case "Entrée - Plat":
                    return new Formule(4, "Entrée/Plat");
                case "Entrée - Dessert":
                    return new Formule(5, "Entrée/Dessert");
                case "Plat - Dessert":
                    return new Formule(6, "Plat/Dessert");
                default:
                    return new Formule(7, "Entrée/Plat/Dessert");
            }
        }
    }
}
