using System.Threading.Tasks;
using BO.DTO.Reponses;
using BO.DTO.Requetes;

namespace DAL.Repertoire
{
    /// <summary>
    /// Interface implémentée par les répertoires ayant la possibilité d'une périodicité
    /// </summary>
    /// <typeparam name="TEntite">L'entité périodique</typeparam>
    public interface IRepertoirePeriodique<TEntite>
    {
        /// <summary>
        /// Permet de récupérer toutes les entités de TEntite sur une période précise
        /// Mise en page incluse
        /// </summary>
        /// <param name="requetePeriodique">La période demandée</param>
        /// <returns>Toutes les entités de TEntite demandées et paginées</returns>
        Task<ReponsePeriodique<TEntite>> GetAllPeriodeAsync(RequetePeriodique requetePeriodique);
    }
}
