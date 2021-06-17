using System.Threading.Tasks;
using BO.DTO.Reponses;
using BO.DTO.Requetes;

namespace DAL.Repertoire
{
    public interface IRepertoirePaginable<TEntite>
    {
        /// <summary>
        /// Permet de récupérer toutes les entitées de TEntite selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <returns>Toutes les entitées de TEntite demandées et paginées</returns>
        Task<ReponsePagination<TEntite>> GetAllAsync(RequetePagination requetePagination);
    }
}
