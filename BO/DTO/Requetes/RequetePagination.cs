namespace BO.DTO.Requetes
{
    /// <summary>
    /// DTO permettant de demander au serveur une mise en page précise des résultats
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
        /// Constructeur de base avec pagination par défaut
        /// </summary>
        public RequetePagination()
        {
            Page = 1;
            TaillePage = 10;
        }

        /// <summary>
        /// Constructeur complet permettant une mise en page précise
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
