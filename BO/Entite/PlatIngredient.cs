using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Ingrédients composant un Plat
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
        /// Constructeur de base de l'objet PlatIngredient
        /// </summary>
        public PlatIngredient() { }

        /// <summary>
        /// Constructeur complet de l'objet PlatIngredient
        /// </summary>
        /// <param name="ingredientPlat">Ingrédient composant le plat</param>
        /// <param name="quantite">Quantité de l'ingrédient composant le plat</param>
        public PlatIngredient(Ingredient ingredientPlat, int quantite)
        {
            IngredientPlat = ingredientPlat;
            Quantite = quantite;
        }
    }
}
