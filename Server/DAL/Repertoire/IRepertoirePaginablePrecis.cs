using System.Threading.Tasks;
using BO.DTO.Reponses;
using BO.DTO.Requetes;

namespace DAL.Repertoire
{
    public interface IRepertoirePaginablePrecis<TEntite>
    {
        /// <summary>
        /// Permet de récupérer une partie des entitées de TEntite selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <param name="id">L'identifiant précisant la partie précise de TEntite demandée</param>
        /// <returns>La partie des entitées TEntite demandée et paginée</returns>
        Task<ReponsePagination<TEntite>> GetAllPrecisAsync(RequetePagination requetePagination, int id);
    }
}
