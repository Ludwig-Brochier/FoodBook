using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTO.Requetes
{
    /// <summary>
    /// Pagination demandée en entrée du serveur
    /// </summary>
    public class RequetePagination
    {
        /// <summary>
        /// Numéro de la page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Taille de la page
        /// </summary>
        public int TaillePage { get; set; }


        /// <summary>
        /// Constructeur de base de l'Objet DTO RequetePagination
        /// </summary>
        public RequetePagination()
        {
            Page = 1;
            TaillePage = 10;
        }

        /// <summary>
        /// Constructeur complet de l'Objet DTO RequetePagination
        /// </summary>
        /// <param name="page">Numéro de la page</param>
        /// <param name="taillePage">Taille de la page</param>
        public RequetePagination(int page, int taillePage)
        {
            Page = page;
            TaillePage = taillePage;
        }
    }
}
