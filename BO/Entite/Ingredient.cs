using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Double Prix { get; set; }


        /// <summary>
        /// Constructeur de base de l'objet Ingredient
        /// </summary>
        public Ingredient() { }

        /// <summary>
        /// Constructeur complet de l'objet Ingredient
        /// </summary>
        /// <param name="idIngredient">Identifiant de l'ingrédient</param>
        /// <param name="intitule">Intitule de l'ingrédient</param>
        /// <param name="prix">Prix moyen de l'ingrédient</param>
        public Ingredient(int? idIngredient, String intitule, Double prix)
        {
            IdIngredient = idIngredient;
            Intitule = intitule;
            Prix = prix;
        }
    }
}
