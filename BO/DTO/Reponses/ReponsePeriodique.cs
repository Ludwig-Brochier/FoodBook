using System;
using System.Collections.Generic;

namespace BO.DTO.Reponses
{
    /// <summary>
    /// DTO permettant au serveur de renvoyer des résultats suite à une demande concernant une période précise
    /// Mise en page supplémentaire des résultats
    /// </summary>
    /// <typeparam name="T">Type affécté par la pagination</typeparam>
    public class ReponsePeriodique<T>
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
        /// Nombre total d'enregistrements
        /// </summary>
        public int? TotalEnregistrements { get; set; }

        /// <summary>
        /// Nombre total de page
        /// Calculé en fonction de la taille de la page
        /// </summary>
        public int? TotalPages => TotalEnregistrements.HasValue ? (int)Math.Ceiling(TotalEnregistrements.Value / (double)TaillePage) : null;

        /// <summary>
        /// Les données de la page
        /// </summary>
        public List<T> Donnees { get; set; }


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
        public ReponsePeriodique(DateTime debut, DateTime fin, int page, int taillePage, int? totalEnregistrements, List<T> donnees)
        {
            Debut = debut;
            Fin = fin;
            Page = page;
            TaillePage = taillePage;
            TotalEnregistrements = totalEnregistrements;
            Donnees = donnees;
        }
    }
}
