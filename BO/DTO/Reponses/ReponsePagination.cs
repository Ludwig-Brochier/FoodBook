using System;
using System.Collections.Generic;

namespace BO.DTO.Reponses
{
    /// <summary>
    /// DTO permettant au serveur de renvoyer des résultats suite à une demande de pagination précise
    /// </summary>
    /// <typeparam name="T">Type affecté par la pagination</typeparam>
    public class ReponsePagination<T>
    {
        /// <summary>
        /// Numéro de la page demandé
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Nombre d'Obj par page
        /// </summary>
        public int TaillePage { get; set; }

        /// <summary>
        /// Nombre total d'Obj
        /// </summary>
        public int? TotalEnregistrements { get; set; }

        /// <summary>
        /// Nombre total de page, en fonction de la taille de la page
        /// </summary>
        public int? TotalPages => TotalEnregistrements.HasValue ? (int)Math.Ceiling(TotalEnregistrements.Value / (double)TaillePage) : null;

        /// <summary>
        /// Les données de la page
        /// </summary>
        public List<T> Donnees { get; set; }


        /// <summary>
        /// Constructeur de base 
        /// </summary>
        public ReponsePagination() { }

        /// <summary>
        /// Constructeur complet 
        /// </summary>
        /// <param name="page">Numéro de la page</param>
        /// <param name="taillePage">Taille de la page</param>
        /// <param name="totalEnregistrements">Nombre total d'enregistrements</param>
        /// <param name="donnees">Données de la page: Liste d'Obj concernés par la pagination</param>
        public ReponsePagination(int page, int taillePage, int? totalEnregistrements, List<Obj> donnees)
        {
            Page = page;
            TaillePage = taillePage;
            TotalEnregistrements = totalEnregistrements;
            Donnees = donnees;
        }
    }
}
