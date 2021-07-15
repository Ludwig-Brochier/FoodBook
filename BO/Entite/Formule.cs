using System;
using System.Collections.Generic;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Formules
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
        /// Constructeur de base de Formule
        /// </summary>
        public Formule() { }

        /// <summary>
        /// Constructeur complet de Formule
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
                IdFormule == autre.IdFormule;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Formule);
        }

        public override int GetHashCode()
        {
            int hashCode = -191435445;
            hashCode = hashCode * -1521134295 + IdFormule.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Intitule);
            return hashCode;
        }
    }
}
