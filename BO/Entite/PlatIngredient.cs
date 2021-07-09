using System;
using System.Collections.Generic;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Ingrédients composant un Plat
    /// Entité fictive
    /// </summary>
    public class PlatIngredient
    {
        /// <summary>
        /// Ingrédient composant le plat
        /// </summary>
        public Ingredient IngredientPlat { get; set; }

        /// <summary>
        /// Quantite de l'ingrédient composant le plat
        /// </summary>
        public int Quantite { get; set; }


        /// <summary>
        /// Constructeur de base de l'entité fictive PlatIngredient
        /// </summary>
        public PlatIngredient() { }

        /// <summary>
        /// Constructeur complet de l'entité fictive PlatIngredient
        /// </summary>
        /// <param name="ingredientPlat">Ingrédient composant le plat</param>
        /// <param name="quantite">Quantité de l'ingrédient composant le plat</param>
        public PlatIngredient(Ingredient ingredientPlat, int quantite)
        {
            IngredientPlat = ingredientPlat;
            Quantite = quantite;
        }

   
        public override int GetHashCode()
        {
            return HashCode.Combine(IngredientPlat, Quantite);
        }

        public override bool Equals(object obj)
        {
            return obj is PlatIngredient ingredient &&
                   EqualityComparer<Ingredient>.Default.Equals(IngredientPlat, ingredient.IngredientPlat);
        }
    }
}
