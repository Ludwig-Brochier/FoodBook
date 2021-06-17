using System.Threading.Tasks;
using BO.Entite;

namespace BLL.Services
{
    public interface IManagementService
    {
        /// <summary>
        /// Permet de récupérer une semaine précise en fonction de son identifiant
        /// </summary>
        /// <param name="idSemaine">Idenfiant de la semaine</param>
        /// <returns>L'objet Semaine demandé</returns>
        Task<Semaine> GetSemaineAsync(int idSemaine);

        /// <summary>
        /// Permet de créer une nouvelle semaine
        /// </summary>
        /// <param name="semaine">La semaine à créer</param>
        /// <returns>L'objet Semaine créé</returns>
        Task<Semaine> InsertSemaineAsync(Semaine semaine);

        /// <summary>
        /// Permet de mettre à jour une semaine éxistante
        /// </summary>
        /// <param name="semaine">Le nouvel objet Semaine</param>
        /// <returns>L'objet Semaine mis à jour</returns>
        Task<Semaine> UpdateSemaineAsync(Semaine semaine);

        /// <summary>
        /// Permet de supprimer une semaine en fonction de son identifiant
        /// </summary>
        /// <param name="idSemaine">L'identifiant de la semaine</param>
        /// <returns bool>Si oui ou non l'objet Semaine est supprimé</returns>
        Task<bool> DeleteSemaineAsync(int idSemaine);
    }
}
