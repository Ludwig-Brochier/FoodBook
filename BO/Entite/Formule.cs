using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
