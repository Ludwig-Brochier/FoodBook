using BO.Entite;
using BO.DTO.Requetes;
using BO.DTO.Reponses;
using BO.DTO.Modeles;
using System.Threading.Tasks;

namespace DAL.Repertoire
{
    /// <summary>
    /// Interface implémentée par le répertoire Plat
    /// Permet le tri des plats
    /// </summary>
    public interface IPlatRepertoire : IRepertoireCRUD<Plat>
    {
        /// <summary>
        /// Permet de récupérer tous les plats selon un filtre et une pagination
        /// </summary>
        /// <param name="requeteFiltresPlats">Le filtre + la pagination</param>
        /// <returns>Les plats demandés filtrés et mis en page</returns>
        Task<ReponsePagination<Plat>> GetAllPlatsAsync(RequeteFiltresPlats requeteFiltresPlats);

        /// <summary>
        /// Permet de récupérer tous les plats selon leurs popularité, plus pagination
        /// </summary>
        /// <param name="requeteFiltresPlats">Le filtre + la pagination</param>
        /// <returns>Les plats demandé filtrés par leurs popularité et mis en page</returns>
        Task<ReponsePagination<PlatPopulaire>> GetAllPlatsPopulaireAsync(RequeteFiltresPlats requeteFiltresPlats);
    }
}
