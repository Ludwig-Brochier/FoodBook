using System;

namespace BO.DTO.Requetes
{
    /// <summary>
    /// DTO permettant de filtrer des plats
    /// Pagination possible
    /// </summary>
    public class RequeteFiltresPlats : RequetePagination
    {
        public bool Populaire { get; set; }

        public string Type { get; set; }

        public int IdIngredient { get; set; }


        public RequeteFiltresPlats() : base() { }

        public RequeteFiltresPlats(bool populaire, string type, int idIngredient, int page, int taillePage) : base(page, taillePage)
        {
            Populaire = populaire;
            Type = type;
            IdIngredient = idIngredient;
        }
    }
}
