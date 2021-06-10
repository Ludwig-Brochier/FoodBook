using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Plats proposés par le restaurateur
    /// </summary>
    public class Plat
    {
        /// <summary>
        /// Identifiant du plat
        /// </summary>
        public int? IdPlat { get; set; }

        /// <summary>
        /// Intitule du plat
        /// </summary>
        public String Intitule { get; set; }

        /// <summary>
        /// Type de plat
        /// </summary>
        public String TypePlat { get; set; }

        /// <summary>
        /// Prix du plat
        /// </summary>
        public Decimal Prix { get; set; }

        /// <summary>
        /// Liste d'Objet PlatIngredient
        /// Représente la liste des ingrédients composant le plat, ainsi que la quantité de l'ingrédient
        /// </summary>
        public List<PlatIngredient> PlatIngredients { get; set; }


        /// <summary>
        /// Constructeur de base de l'objet Plat
        /// </summary>
        public Plat() { }

        /// <summary>
        /// Constructeur complet de l'objet Plat
        /// </summary>
        /// <param name="idPlat">Identifiant du plat</param>
        /// <param name="intitule">Intitule du plat</param>
        /// <param name="typePlat">Type de plat</param>
        /// <param name="prix">Prix du plat</param>
        /// <param name="platIngredients">Représente la liste des ingrédients composant le plat, ainsi que la quantité de l'ingrédient</param>
        public Plat(int? idPlat, String intitule, String typePlat, Decimal prix, List<PlatIngredient> platIngredients)
        {
            IdPlat = idPlat;
            Intitule = intitule;
            TypePlat = typePlat;
            Prix = prix;
            PlatIngredients = platIngredients;
        }
    }
}
