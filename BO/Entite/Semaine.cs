using System;
using System.Collections.Generic;

namespace BO.Entite
{
    /// <summary>
    /// Représente la Semaine de travaille du réstaurateur
    /// </summary>
    public class Semaine
    {
        /// <summary>
        /// Identifiant de la semaine
        /// </summary>
        public int? IdSemaine { get; set; }

        /// <summary>
        /// Date de début de la semaine
        /// </summary>
        public DateTime DteDebut { get; set; }

        /// <summary>
        /// Date de fin de la semaine
        /// </summary>
        public DateTime DteFin { get; set; }

        /// <summary>
        /// Date butoir de réservation de la semaine
        /// Donnée calculée: 3 jours avant le début de la semaine
        /// </summary>
        public DateTime DteButoir => DteDebut.AddDays(-3);

        /// <summary>
        /// La liste des Objets Menu planifié pour la semaine
        /// </summary>
        public List<Menu> Menus { get; set; }


        /// <summary>
        /// Constructeur de base de l'objet Semaine
        /// </summary>
        public Semaine() { }

        /// <summary>
        /// Constructeur complet de l'objet Semaine
        /// L'attribut DteButoir est une donnée calculée: Ajoute -3 jours au paramètre dteDebut
        /// </summary>
        /// <param name="idSemaine">Identifiant de la semaine</param>
        /// <param name="dteDebut">Date de début de la semaine</param>
        /// <param name="dteFin">Date de fin de la semaine</param>
        /// <param name="menus">Liste des menus planifié pour la semaine</param>
        public Semaine(int? idSemaine, DateTime dteDebut, DateTime dteFin, List<Menu> menus)
        {
            IdSemaine = idSemaine;
            DteDebut = dteDebut;
            DteFin = dteFin;
            Menus = menus;
        }


        public bool Equals(Semaine autre)
        {
            return autre != null &&
                IdSemaine == autre.IdSemaine &&
                DteDebut == autre.DteDebut &&
                DteFin == autre.DteFin &&
                DteButoir == autre.DteButoir &&
                Menus == autre.Menus;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Semaine);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdSemaine, DteDebut, DteFin, DteButoir, Menus);
        }
    }
}
