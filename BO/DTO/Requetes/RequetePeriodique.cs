namespace BO.DTO.Requetes
{
    /// <summary>
    /// DTO permettant de demander au serveur des données sur une période précise d'une ou plusieurs semaines
    /// Permet aussi une mise en page précise des résultats
    /// </summary>
    public class RequetePeriodique
    {
        /// <summary>
        /// Début de la période
        /// Représente IdSemaine de l'objet Semaine
        /// </summary>
        public int Debut { get; set; }

        /// <summary>
        /// Fin de la période
        /// Représente IdSemaine de l'objet Semaine
        /// </summary>
        public int Fin { get; set; }

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
        /// </summary>
        public RequetePeriodique() {
            Debut = 1;
            Fin = 1;
            Page = 1;
            TaillePage = 10;
        }

        /// <summary>
        /// Constructeur pour période d'une semaine, Fin est égal à Debut 
        /// Mise en page par défaut
        /// </summary>
        /// <param name="debut">L'IdSemaine de la période demandée</param>
        public RequetePeriodique(int debut) 
        {
            Debut = debut;
            Fin = debut;
            Page = 1;
            TaillePage = 10;
        }

        /// <summary>
        /// Constructeur pour période d'une semaine, Fin est égal à Debut, et mise en page 
        /// </summary>
        /// <param name="debut">L'IdSemaine de la période demandée</param>
        /// <param name="page">Numéro de la page</param>
        /// <param name="taillePage">Taille de la page</param>
        public RequetePeriodique(int debut, int page, int taillePage)
        {
            Debut = debut;
            Fin = debut;
            Page = page;
            TaillePage = taillePage;
        }

        /// <summary>
        /// Constructeur pour période de plusieurs semaine
        /// Mise en page par défaut
        /// </summary>
        /// <param name="debut">l'IdSemaine de début de période</param>
        /// <param name="fin">L'IdSemaine de fin de période</param>
        public RequetePeriodique(int debut, int fin)
        {
            Debut = debut;
            Fin = fin;
            Page = 1;
            TaillePage = 10;
        }

        /// <summary>
        /// Constructeur complet pour période de plusieurs semaines, et mise en page
        /// </summary>
        /// <param name="debut">L'IdSemaine de début de période</param>
        /// <param name="fin">L'IdSemaine de fin de période</param>
        /// <param name="page">Numéro de la page</param>
        /// <param name="taillePage">Taille de la page</param>
        public RequetePeriodique(int debut, int fin, int page, int taillePage)
        {
            Debut = debut;
            Fin = fin;
            Page = page;
            TaillePage = taillePage;
        }
    }
}
