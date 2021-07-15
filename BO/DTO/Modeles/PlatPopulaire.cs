using BO.Entite;

namespace BO.DTO.Modeles
{
    /// <summary>
    /// DTO permettant de récupérer un plat avec son nombre de réservations
    /// En lien avec le DTO RequeteFiltres
    /// </summary>
    public class PlatPopulaire
    {
        /// <summary>
        /// Le plat
        /// </summary>
        public Plat Plat { get; set; } 

        /// <summary>
        /// Le nombre de réservations
        /// </summary>
        public int NbReservations { get; set; }


        /// <summary>
        /// Constructeur de base
        /// </summary>
        public PlatPopulaire() { }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="plat">Le plat</param>
        /// <param name="nbReservations">Le nombre de réservations</param>
        public PlatPopulaire(Plat plat, int nbReservations)
        {
            Plat = plat;
            NbReservations = nbReservations;
        }
    }
}
