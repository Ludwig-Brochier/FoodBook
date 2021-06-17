using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IReservationService
    {
        /// <summary>
        /// Permet de récupérer toutes les réservations d'une semaine précise selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <param name="idSemaine">L'identifiant de la semaine précise</param>
        /// <returns>Les réservations de la semaine mises en page</returns>
        Task<ReponsePagination<Reservation>> GetAllReservationsAsync(RequetePagination requetePagination, int idSemaine);

        /// <summary>
        /// Permet de récupérer une réservation précise via son ID
        /// </summary>
        /// <param name="idReservation">Identifiant de la réservation</param>
        /// <returns>La réservation demandée</returns>
        Task<Reservation> GetReservationAsync(int idReservation);

        /// <summary>
        /// Permet d'ajouter une réservation
        /// </summary>
        /// <param name="reservation">La réservation à ajouter</param>
        /// <returns>La réservation ajoutée</returns>
        Task<Reservation> InsertReservationAsync(Reservation reservation);

        /// <summary>
        /// Permet de mettre à jour une réservation
        /// </summary>
        /// <param name="reservation">Les données de la réservation</param>
        /// <returns>La réservation mise à jour</returns>
        Task<Reservation> UpdateReservation(Reservation reservation);

        /// <summary>
        /// Permet de supprimer une réservation précise via son ID
        /// </summary>
        /// <param name="idReservation">Identifiant de la réservation</param>
        /// <returns>Si oui ou non la réservation est supprimée</returns>
        Task<bool> DeleteReservationAsync(int idReservation);
    }
}
