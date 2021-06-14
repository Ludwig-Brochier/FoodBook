using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepertoireGenerique<TEntite>
    {
        /// <summary>
        /// Permet de récupérer un TEntite précis via son ID
        /// </summary>
        /// <param name="id">Identifiant de TEntite</param>
        /// <returns>TEntite demandé</returns>
        Task<TEntite> GetAsync(int id);
    }
}
