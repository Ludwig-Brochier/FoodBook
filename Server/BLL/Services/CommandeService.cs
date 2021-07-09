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

            List<PlatIngredient> ingredientsReservations = new();

            foreach (var reservation in reservations)
            {
                bool[] formule = GestionFormule(reservation);
                int multiplicateur = reservation.NbPersonne;

                Menu menu = await _restaurationService.GetMenuAsync((int)reservation.Menu.IdMenu);

                List<Plat> platsReservation = new();
                foreach (var platMenu in menu.Plats)
                {
                    if (formule[0] == true && platMenu.TypePlat == "Entrée")
                    {
                        platsReservation.Add(await _restaurationService.GetPlatAsync((int)platMenu.IdPlat));
                    }

                    else if (formule[1] == true && platMenu.TypePlat == "Plat")
                    {
                        platsReservation.Add(await _restaurationService.GetPlatAsync((int)platMenu.IdPlat));
                    }

                    else if (formule[2] == true && platMenu.TypePlat == "Dessert")
                    {
                        platsReservation.Add(await _restaurationService.GetPlatAsync((int)platMenu.IdPlat));
                    }
                }

                List<PlatIngredient> platIngredientsReservation = new();
                foreach (var plat in platsReservation)
                {
                    List<PlatIngredient> list = await GetIngredientsPlatAsync(plat, multiplicateur);

                    foreach (var platIngredient in list)
                    {
                        if (platIngredientsReservation.Exists(pi => pi.IngredientPlat.Equals(platIngredient.IngredientPlat)))
                        {
                            PlatIngredient oldPI = platIngredientsReservation.Find(pi => pi.IngredientPlat.Equals(platIngredient.IngredientPlat));

                            int index = platIngredientsReservation.FindIndex(0, pi => pi.IngredientPlat.Equals(platIngredient.IngredientPlat));
                            platIngredientsReservation.RemoveAt(index);

                            platIngredientsReservation.Add(new PlatIngredient(platIngredient.IngredientPlat, (oldPI.Quantite + platIngredient.Quantite)));
                        }

                        else
                        {
                            platIngredientsReservation.Add(platIngredient);
                        }
                    }
                }

                foreach (var PI in platIngredientsReservation)
                {
                    if (ingredientsReservations.Contains(PI))
                    {
                        PlatIngredient oldPI = ingredientsReservations.Find(pi => pi.IngredientPlat.Equals(PI.IngredientPlat));

                        int index = ingredientsReservations.FindIndex(0, pi => pi.IngredientPlat.Equals(PI.IngredientPlat));
                        ingredientsReservations.RemoveAt(index);

                        ingredientsReservations.Add(new PlatIngredient(PI.IngredientPlat, (oldPI.Quantite + PI.Quantite)));
                    }

                    else
                    {
                        ingredientsReservations.Add(PI);
                    }
                }
            }
            
            return new ReponsePeriodique<PlatIngredient>(requetePeriodique.Debut, requetePeriodique.Fin, requetePeriodique.Page, requetePeriodique.TaillePage, ingredientsReservations.Count, ingredientsReservations);
        }
        
        private bool[] GestionFormule(Reservation reservation)
        {
            bool entree = false;
            bool plat = false;
            bool dessert = false;

            switch (reservation.Formule.IdFormule)
            {
                case 1:
                    entree = true;
                    break;
                case 2:
                    plat = true;
                    break;
                case 3:
                    dessert = true;
                    break;
                case 4:
                    entree = true;
                    plat = true;
                    break;
                case 5:
                    entree = true;
                    dessert = true;
                    break;
                case 6:
                    plat = true;
                    dessert = true;
                    break;
                default:
                    entree = true;
                    plat = true;
                    dessert = true;
                    break;
            }

            bool[] tableau = new bool[3] { entree, plat, dessert };

            return tableau;
        }

        private async Task<List<PlatIngredient>> GetIngredientsPlatAsync(Plat plat, int multiplicateur)
        {
            List<PlatIngredient> ingredients = new();

            foreach (var platIngredient in plat.PlatIngredients)
            {
                Ingredient ingredient = await _restaurationService.GetIngredientAsync((int)platIngredient.IngredientPlat.IdIngredient);
                int quantite = platIngredient.Quantite * multiplicateur;

                ingredients.Add(new PlatIngredient(ingredient, quantite));
            }

            return ingredients;
        }
    }
}
