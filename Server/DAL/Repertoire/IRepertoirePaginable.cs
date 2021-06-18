using System.Threading.Tasks;
using BO.DTO.Reponses;
using BO.DTO.Requetes;

namespace DAL.Repertoire
{
    /// <summary>
    /// Interface implémentée par les répertoires ayant l'utilité d'une mise en page
    /// </summary>
    /// <typeparam name="TEntite">L'entité concernée par la mise en page</typeparam>
    public interface IRepertoirePaginable<TEntite>
    {
        /// <summary>
        /// Permet de récupérer toutes les entités de TEntite selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <returns>Toutes les entités de TEntite demandées et paginées</returns>
        Task<ReponsePagination<TEntite>> GetAllAsync(RequetePagination requetePagination);
    }
}
