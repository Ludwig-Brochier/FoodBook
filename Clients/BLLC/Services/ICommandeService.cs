using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System.Threading.Tasks;

namespace BLLC.Services
{
    public interface ICommandeService
    {
        /// <summary>
        /// Permet de récupérer les ingrédients (plus la quantité) à commander en fonction des réservations sur une période précise
        /// </summary>
        /// <param name="requetePeriodique">la période précise</param>
        /// <returns>Les ingrédients (plus la quantité) à commander pour une période précise</returns>
        Task<ReponsePeriodique<PlatIngredient>> GetCommandeIngredientsAsync(RequetePeriodique requetePeriodique);
    }
}
