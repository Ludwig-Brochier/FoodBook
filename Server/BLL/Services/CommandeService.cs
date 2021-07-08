using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class CommandeService : ICommandeService
    {
        private readonly IReservationService _reservationService;
        private readonly IRestaurationService _restaurationService;

        public CommandeService(IReservationService reservationService, IRestaurationService restaurationService)
        {
            _reservationService = reservationService;
            _restaurationService = restaurationService;
        }

        public async Task<ReponsePeriodique<PlatIngredient>> CommandeIngredientsAsync(RequetePeriodique requetePeriodique)
        {    
            ReponsePeriodique<Reservation> reponsePeriodique = await _reservationService.GetAllReservationsAsync(requetePeriodique);
            List<Reservation> reservations = reponsePeriodique.Donnees;

            List<PlatIngredient> ingredients = new();
            foreach (var reservation in reservations)
            {
                Menu menu = await _restaurationService.GetMenuAsync((int)reservation.Menu.IdMenu);

                List<Plat> plats = new();
                foreach (var plat in menu.Plats)
                {
                    plats.Add(await _restaurationService.GetPlatAsync((int)plat.IdPlat));
                }

                foreach (var plat1 in plats)
                {
                    foreach (var ingredient in plat1.PlatIngredients)
                    {
                        ingredients.Add(ingredient);
                    }
                }
            }

            return new ReponsePeriodique<PlatIngredient>(requetePeriodique.Debut, requetePeriodique.Fin, requetePeriodique.Page, requetePeriodique.TaillePage, ingredients.Count, ingredients);
        }  
    }
}
