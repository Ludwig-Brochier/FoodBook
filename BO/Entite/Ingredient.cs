using System;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Ingrédients
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Identifiant de l'ingredient
        /// </summary>
        public int? IdIngredient { get; set; }

        /// <summary>
        /// Intitule de l'ingredient
        /// </summary>
        public String Intitule { get; set; }

        /// <summary>
        /// Prix moyen de l'ingrédient
        /// </summary>
        public float Prix { get; set; }


        /// <summary>
        /// Constructeur de base d'Ingredient
        /// </summary>
        public Ingredient() { }

        /// <summary>
        /// Constructeur complet d'Ingredient
        /// </summary>
        /// <param name="idIngredient">Identifiant de l'ingrédient</param>
        /// <param name="intitule">Intitule de l'ingrédient</param>
        /// <param name="prix">Prix moyen de l'ingrédient</param>
        public Ingredient(int? idIngredient, String intitule, float prix)
        {
            IdIngredient = idIngredient;
            Intitule = intitule;
            Prix = prix;
        }


        public bool Equals(Ingredient autre)
        {
            return autre != null &&
                IdIngredient == autre.IdIngredient;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Ingredient);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdIngredient, Intitule, Prix);
        }
    }
}
