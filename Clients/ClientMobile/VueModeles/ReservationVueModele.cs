using System.Threading.Tasks;
using BO.Entite;
using ClientMobile.Modeles;
using ClientMobile.VMDatas;

namespace ClientMobile.VueModeles
{
    /// <summary>
    /// Vue Modele de la page des réservation
    /// </summary>
    public class ReservationVueModele : VueModelesBase
    {
        private readonly ReservationModel _reservationModel = ReservationModel.Instance; //Instance du Singleton

        public ReservationVueModele()
        {
            Menu = MenuService.FromMenu(_reservationModel.Menu);
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

        /// <summary>
        /// Gestion de l'affichage de la PopUp Validation réservation
        /// </summary>
        private bool _popUp = false;
        public bool PopUp
        {
            get => _popUp;
            set => Set(ref _popUp, value);
        }

        /// <summary>
        /// Gestion du message de la PopUp Validation réservation
        /// </summary>
        private string _messagePopUpResa = "";
        public string MessagePopUpResa
        {
            get => _messagePopUpResa;
            set => Set(ref _messagePopUpResa, value);
        }

        /// <summary>
        /// Méthode pour la réservation d'un menu
        /// </summary>
        /// <returns></returns>
        public async Task ReserverMenu()
        {
            //Test si tous les champs sont renseignés
            if (Nom != string.Empty && Prenom != string.Empty && NumTel != string.Empty && NbParticipants >= 1 && NbParticipants <= 9 && FormuleResa != string.Empty)
            {
                _reservationModel.Nom = Nom;
                _reservationModel.Prenom = Prenom;
                _reservationModel.NumTel = NumTel;
                _reservationModel.NbParticipants = NbParticipants;
                _reservationModel.FormuleResa = GetFormule(FormuleResa);

                Reservation reservation = await _reservationModel.AjoutReservation();

                //Test si la réservation a bien été ajoutée
                MessagePopUpResa = reservation.IdReservation != null ? "Votre réservation est prise en compte." : "Une erreur est survenue.";

                PopUp = true; //Affichage PopUp
            }

            else
            {
                MessagePopUpResa = "Veuillez renseigner tous les champs.";
                PopUp = true; //Affichage PopUp
            }
        }

        /// <summary>
        /// Transforme l'intitulé d'une formule en object Formule
        /// </summary>
        /// <param name="intitule">Intitulé de la formule choisie</param>
        /// <returns>L'object Formule</returns>
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

        public void ClosePopup()
        {
            PopUp = false;
        }
    }
}
