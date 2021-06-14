using System.Threading.Tasks;
using BO.DTO.Reponses;
using BO.DTO.Requetes;

namespace DAL.Repertoire
{
    public interface IRepertoirePaginable<TEntite>
    {
        /// <summary>
        /// Permet de récupérer une liste paginée de TEntite
        /// </summary>
        /// <param name="requetePagination">La pagination attendue</param>
        /// <returns>La liste de TEntite demandée et paginée</returns>
        Task<ReponsePagination<TEntite>> GetAllAsync(RequetePagination requetePagination);
    }
}
