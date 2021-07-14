using System;

namespace BO.DTO.Requetes
{
    /// <summary>
    /// DTO permettant de filtrer des résultats
    /// Pagination possible
    /// </summary>
    public class RequeteFiltres : RequetePagination
    {
        /// <summary>
        /// Le filtre en question
        /// </summary>
        public String Filtre { get; set; }


        /// <summary>
        /// Constructeur de base
        /// </summary>
        public RequeteFiltres() :  base() { }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="filtre">Le filtre</param>
        /// <param name="page">Numéro de la page</param>
        /// <param name="taillePage">Taille de la page</param>
        public RequeteFiltres(String filtre, int page, int taillePage) : base(page, taillePage)
        {
            Filtre = filtre;
        }
    }
}
