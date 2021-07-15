using System;
using System.Collections.Generic;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Plats
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
        public float Prix { get; set; }

        /// <summary>
        /// Liste de PlatIngredient
        /// Représente la liste des ingrédients composant le plat, ainsi que la quantité de l'ingrédient
        /// </summary>
        public List<PlatIngredient> PlatIngredients { get; set; }


        /// <summary>
        /// Constructeur de base de Plat
        /// </summary>
        public Plat() { }

        /// <summary>
        /// Constructeur complet de Plat
        /// </summary>
        /// <param name="idPlat">Identifiant du plat</param>
        /// <param name="intitule">Intitule du plat</param>
        /// <param name="typePlat">Type de plat</param>
        /// <param name="prix">Prix du plat</param>
        /// <param name="platIngredients">Représente la liste des ingrédients composant le plat, ainsi que la quantité de l'ingrédient</param>
        public Plat(int? idPlat, String intitule, String typePlat, float prix, List<PlatIngredient> platIngredients)
        {
            IdPlat = idPlat;
            Intitule = intitule;
            TypePlat = typePlat;
            Prix = prix;
            PlatIngredients = platIngredients;
        }


        public bool Equals(Plat autre)
        {
            return autre != null &&
                IdPlat == autre.IdPlat;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Plat);
        }

        public override int GetHashCode()
        {
            int hashCode = 37635952;
            hashCode = hashCode * -1521134295 + IdPlat.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Intitule);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TypePlat);
            hashCode = hashCode * -1521134295 + Prix.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<PlatIngredient>>.Default.GetHashCode(PlatIngredients);
            return hashCode;
        }
    }
}
