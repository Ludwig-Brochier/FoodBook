using BO.Entite;

namespace DAL.Repertoire
{
    /// <summary>
    /// Interface implémentée par le répertoire Ingredient
    /// </summary>
    public interface IIngredientRepertoire : IRepertoireGenerique<Ingredient>, IRepertoirePaginable<Ingredient>
    {
    }
}
