using System;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Formules proposées par le restaurateur
    /// </summary>
    public class Formule
    {
        /// <summary>
        /// Identifiant de la formule
        /// </summary>
        public int? IdFormule { get; set; }

        /// <summary>
        /// Intitulé de la formule
        /// </summary>
        public String Intitule { get; set; }


        /// <summary>
        /// Constructeur de base de l'objet Formule
        /// </summary>
        public Formule() { }

        /// <summary>
        /// Constructeur complet de l'objet Formule
        /// </summary>
        /// <param name="idFormule">Identifiant de la formule</param>
        /// <param name="intitule">Intitule de la formule</param>
        public Formule(int? idFormule, String intitule)
        {
            IdFormule = idFormule;
            Intitule = intitule;
        }


        public bool Equals(Formule autre)
        {
            return autre != null &&
                IdFormule == autre.IdFormule &&
                Intitule == autre.Intitule;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Formule);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdFormule, Intitule);
        }
    }
}
