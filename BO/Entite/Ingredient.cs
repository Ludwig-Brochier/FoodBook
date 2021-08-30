using System;
using System.Collections.Generic;

namespace BO.Entite
{
    /// <summary>
    /// Représente les Ingrédients
    /// </summary>
    public class Ingredient : IComparable<Ingredient>
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
                IdIngredient == autre.IdIngredient &&
                Intitule == autre.Intitule &&
                Prix == autre.Prix;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Ingredient);
        }

        public override string ToString()
        {
            return Intitule;
        }

        public override int GetHashCode()
        {
            int hashCode = -1107114518;
            hashCode = hashCode * -1521134295 + IdIngredient.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Intitule);
            hashCode = hashCode * -1521134295 + Prix.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Ingredient other)
        {
            if (IdIngredient < other.IdIngredient)
            {
                return -1;
            }

            else
            {
                return 1;
            }
        }
    }
}
