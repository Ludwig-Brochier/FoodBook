using System;

namespace BO.DTO.Requetes
{
    /// <summary>
    /// DTO permettant de demander au serveur des données sur une période de date à date précise
    /// Permet aussi une mise en page précise des résultats
    /// </summary>
    public class RequetePeriodique
    {
        /// <summary>
        /// Début de la période
        /// </summary>
        public DateTime Debut { get; set; }

        /// <summary>
        /// Fin de la période
        /// </summary>
        public DateTime Fin { get; set; }

        /// <summary>
        /// Numéro de la page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Taille de la page
        /// </summary>
        public int TaillePage { get; set; }


        /// <summary>
        /// Constructeur de base
        /// Pré-rempli avec la date du jour, sur une période de 7 jours
        /// Pagination de base
        /// </summary>
        public RequetePeriodique()
        {
            Debut = DateTime.Today;
            Fin = DateTime.Today.AddDays(7);
            Page = 1;
            TaillePage = 15;
        }

        /// <summary>
        /// Constructeur pour une période précise
        /// Pagination de base
        /// </summary>
        /// <param name="debut">Date de début de période</param>
        /// <param name="fin">Date de fin de période</param>
        public RequetePeriodique(DateTime debut, DateTime fin)
        {
            Debut = debut;
            Fin = fin;
            Page = 1;
            TaillePage = 15;
        }

        /// <summary>
        /// Constructeur complet pour une période précise et une pagination précise
        /// </summary>
        /// <param name="debut">Date de début de période</param>
        /// <param name="fin">Date de fin de période</param>
        /// <param name="page">Numéro de la page</param>
        /// <param name="taillePage">Taille de la page</param>
        public RequetePeriodique(DateTime debut, DateTime fin, int page, int taillePage)
        {
            Debut = debut;
            Fin = fin;
            Page = page;
            TaillePage = taillePage;
        }
    }
}
