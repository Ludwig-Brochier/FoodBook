using System;
using System.Collections.Generic;

namespace BO.DTO.Reponses
{
    /// <summary>
    /// DTO permettant au serveur de renvoyer des résultats suite à une demande concernant une période précise
    /// Mise en page supplémentaire des résultats
    /// </summary>
    /// <typeparam name="T">Type affécté par la pagination</typeparam>
    public class ReponsePeriodique<T> : ReponsePagination<T>
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
        /// Constructeur de base
        /// </summary>
        public ReponsePeriodique() { }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="debut">Date de début de période</param>
        /// <param name="fin">Date de fin de période</param>
        /// <param name="page">Numéro de la page</param>
        /// <param name="taillePage">Taille de la page</param>
        /// <param name="totalEnregistrements">Nombre total d'enregistrements</param>
        /// <param name="donnees">Données de la page : liste typée</param>
        public ReponsePeriodique(DateTime debut, DateTime fin, int page, int taillePage, int? totalEnregistrements, List<T> donnees) : base(page, taillePage, totalEnregistrements, donnees)
        {
            Debut = debut;
            Fin = fin;
        }
    }
}
