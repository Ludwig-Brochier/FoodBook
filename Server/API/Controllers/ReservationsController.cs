using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using BO.DTO.Requetes;
using Microsoft.AspNetCore.Http;
using BO.Entite;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ReservationsController : ControllerBase
    {
        // Appel du service reservation via Injecteur de dépendance
        private readonly IReservationService _reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        /// <summary>
        /// Permet de récupérer toutes les réservations selon une pagination précise
        /// </summary>
        /// <param name="requetePagination">La pagination demandée</param>
        /// <returns>Les réservations mise en page</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllReservationsAsync([FromQuery]RequetePagination requetePagination)
        {
            // Méthode pour récupérer toutes les réservations
            return Ok(await _reservationService.GetAllReservationsAsync(requetePagination));
        }

        /// <summary>
        /// Permet de récupérer une réservation précise via son ID
        /// </summary>
        /// <param name="idReservation">L'identifiant de la réservation</param>
        /// <returns>La réservation demandée</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReservationAsync([FromRoute]int idReservation)
        {
            // Méthode pour récupérer une réservation
            Reservation reservation = await _reservationService.GetReservationAsync(idReservation);

            if (reservation != null)
            {
                // Résultat Ok + réservation
                return Ok(reservation);
            }

            else
            {
                // Réservation introuvable
                return NotFound();
            }
        }

        /// <summary>
        /// Permet d'ajouter une réservation
        /// </summary>
        /// <param name="reservation">La réservation à ajouter</param>
        /// <returns>La nouvelle réservation</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertReservationAsync([FromBody]Reservation reservation)
        {
            //Méthode pour ajouter une réservation
            Reservation newReservation = await _reservationService.InsertReservationAsync(reservation);

            if (newReservation != null)
            {
                // Réservation crée, donc retourne la nouvelle réservation en appelant la méthode Get
                return CreatedAtAction(nameof(GetReservationAsync), new { id = newReservation.IdReservation }, newReservation);
            }

            else
            {
                // La requête n'est pas conforme
                return BadRequest();
            }
        }

        /// <summary>
        /// Permet de mettre à jour une réservation précise via son ID
        /// </summary>
        /// <param name="idReservation">L'identifiant de la réservation</param>
        /// <param name="reservation">La nouvelle réservation</param>
        /// <returns>La réservation modifiée</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateReservationAsync([FromRoute]int idReservation, [FromBody]Reservation reservation)
        {
            if (reservation == null || idReservation != reservation.IdReservation)
            {
                // La requête n'est pas conforme
                return BadRequest();
            }

            else
            {
                // Méthode pour mettre à jour une réservation
                Reservation updateReservation = await _reservationService.UpdateReservation(reservation);

                if (updateReservation != null)
                {
                    // Résultat Ok + réservation modifiée
                    return Ok(updateReservation);
                }

                else
                {
                    // Réservation introuvable
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// Permer de supprimer une réservation précise via son ID
        /// </summary>
        /// <param name="idReservation">L'identifiant de la réservation</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReservationAsync([FromRoute]int idReservation)
        {
            // Méthode pour supprimer une réservation
            if (await _reservationService.DeleteReservationAsync(idReservation))
            {
                // La réservation est bien supprimée
                return NoContent();
            }

            else
            {
                // Réservation introuvable
                return NotFound();
            }
        }
    }
}
