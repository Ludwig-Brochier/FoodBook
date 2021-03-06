using BO.Entite;
using System.Threading.Tasks;
using BLLC.Services;

namespace ClientMobile.Modeles
{
    /// <summary>
    /// Modele de l'entité Reservation
    /// </summary>
    public class ReservationModel : ModeleBase
    {
        private readonly IReservationService _reservationService = new ReservationService();
        private static ReservationModel _instance;
        private static object verrou = new object();

        /// <summary>
        /// Singleton du model de Reservation
        /// </summary>
        public static ReservationModel Instance {
            get
            {
                if(_instance == null)
                {
                    lock(verrou) //Thread safe
                    {
                        if(_instance == null)
                        {
                            _instance = new ReservationModel();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Méthode pour ajouter une réservation
        /// Consomme l'API via la BLLC
        /// </summary>
        /// <returns>La réservation</returns>
        public async Task<Reservation> AjoutReservation()
        {
            Reservation reservation = new Reservation(0, Nom, Prenom, NumTel, NbParticipants, Menu, FormuleResa);
            return await _reservationService.InsertReservationAsync(reservation);
        }

        //Les données utiles pour la création d'une réservation

        private Menu _menu;
        public Menu Menu
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

        private Formule _formuleResa;
        public Formule FormuleResa
        {
            get => _formuleResa;
            set => Set(ref _formuleResa, value);
        }
    }
}
