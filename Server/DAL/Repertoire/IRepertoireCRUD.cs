using System.Threading.Tasks;

namespace DAL.Repertoire
{
    public interface IRepertoireCRUD<TEntite> : IRepertoireGenerique<TEntite>
    { 
        /// <summary>
        /// Permet d'ajouter un nouveau TEntite
        /// </summary>
        /// <param name="entite">TEntite à ajouter</param>
        /// <returns>Le TEntite ajouté</returns>
        Task<TEntite> InsertAsync(TEntite entite);

        /// <summary>
        /// Permer de mettre à jour un TEntite précis
        /// </summary>
        /// <param name="entite">Le nouveau TEntite</param>
        /// <returns>Le TEntite mis à jour</returns>
        Task<TEntite> UpdateAsync(TEntite entite);

        /// <summary>
        /// Permet de supprimer un TEntite précis via son ID
        /// </summary>
        /// <param name="id">Identifiant de TEntite</param>
        /// <returns>Booléen si vrai ou faux</returns>
        Task<bool> DeleteAsync(int id);
    }
}
