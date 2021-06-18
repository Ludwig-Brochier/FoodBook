using System.Threading.Tasks;

namespace DAL.Repertoire
{   
    /// <summary>
    /// Interface implémentée par les répertoires génériques
    /// Répertoire en lecture seule
    /// </summary>
    /// <typeparam name="TEntite">L'entité concernée</typeparam>
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
