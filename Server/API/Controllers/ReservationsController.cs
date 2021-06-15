using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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


        [HttpGet]
        public async Task<IActionResult> GetAllReservationsAsync([FromQuery]RequetePagination requetePagination)
        {
            // Appel de la méthode pour récupérer toutes les réservation selon une pagination précise
            return Ok(await _reservationService.GetAllReservationsAsync(requetePagination));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReservationAsync([FromRoute]int idReservation)
        {
            Reservation reservation = await _reservationService.GetReservationAsync(idReservation);

            if (reservation != null)
            {
                return Ok(reservation);
            }

            else
            {
                return NotFound();
            }
        }
    }
}
