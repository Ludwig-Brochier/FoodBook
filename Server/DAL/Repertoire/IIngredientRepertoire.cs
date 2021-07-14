using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System.Threading.Tasks;

namespace DAL.Repertoire
{
    /// <summary>
    /// Interface implémentée par le répertoire Ingredient
    /// </summary>
    public interface IIngredientRepertoire : IRepertoireGenerique<Ingredient>, IRepertoirePaginable<Ingredient>
    {
        public Task<ReponsePeriodique<PlatIngredient>> GetCommandeIngredientsAsync(RequetePeriodique requetePeriodique);
    }
}
