using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System.Collections.Generic;
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

        /// <summary>
        /// Permet de récupérer une liste d'ingrédients + quantité (PlatIngredient) sur une période précise
        /// Pagination possible
        /// </summary>
        /// <param name="requetePeriodique">Représente la période précise</param>
        /// <returns>Liste de PlatIngredient</returns>
        public async Task<ReponsePeriodique<PlatIngredient>> CommandeIngredientsAsync(RequetePeriodique requetePeriodique)
        {    
            // Récupère les réservations de la période précisée
            ReponsePeriodique<Reservation> reponsePeriodique = await _reservationService.GetAllReservationsAsync(requetePeriodique);
            List<Reservation> reservations = reponsePeriodique.Donnees; // Les réservations

            List<PlatIngredient> ingredientsReservations = new(); // Instanciation de la liste des ingrédients à commander

            // Boucle toutes les réservations
            foreach (var reservation in reservations)
            {
                int multiplicateur = reservation.NbPersonne; // Nombre de personne participant à la réservation

                List<Plat> platsReservation = await GetPlatsReservation(reservation); // Récupère tous les plats de la réservation

                // Boucle les plats de la réservation
                foreach (var plat in platsReservation)
                {
                    // Les ingrédients du plat, en fonction du multiplicateur
                    List<PlatIngredient> ingredientPlat = await GetIngredientsPlatAsync(plat, multiplicateur);

                    // Ajoute la liste des ingrédients du plat à la liste des ingrédients à commander, en gérant les doublons
                    ingredientsReservations = GestionDoublons(ingredientPlat, ingredientsReservations);
                }                
            }

            // Tri de la liste des ingrédients à commander
            ingredientsReservations.Sort();
            
            return new ReponsePeriodique<PlatIngredient>(requetePeriodique.Debut, requetePeriodique.Fin, requetePeriodique.Page, requetePeriodique.TaillePage, ingredientsReservations.Count, ingredientsReservations);
        }
        
        /// <summary>
        /// Permet de gérer la formule d'une réservation
        /// </summary>
        /// <param name="reservation">La réservation impactée par une formule</param>
        /// <returns>Un tableau de booléen indiquant si la formule possède une entrée, un plat, un dessert</returns>
        private bool[] GestionFormule(Reservation reservation)
        {
            bool entree = false;
            bool plat = false;
            bool dessert = false;

            // Test l'identifiant de la formule
            switch (reservation.Formule.IdFormule)
            {
                case 1: // Entrée
                    entree = true;
                    break;
                case 2: // Plat
                    plat = true;
                    break;
                case 3: // Dessert
                    dessert = true;
                    break;
                case 4: // Entrée + Plat
                    entree = true;
                    plat = true;
                    break;
                case 5: // Entrée + Dessert
                    entree = true;
                    dessert = true;
                    break;
                case 6: // Plat + Dessert
                    plat = true;
                    dessert = true;
                    break;
                default: // IdFormule = 7 => Entrée + Plat + Dessert
                    entree = true;
                    plat = true;
                    dessert = true;
                    break;
            }

            bool[] tableau = new bool[3] { entree, plat, dessert };

            return tableau;
        }

        /// <summary>
        /// Permet d'ajouter une liste à une liste finale en gérant les doublons
        /// </summary>
        /// <param name="listeBase">La liste de départ</param>
        /// <param name="listeFinale">La liste finale, sans doublons</param>
        /// <returns>La liste finale, sans doublons</returns>
        private List<PlatIngredient> GestionDoublons(List<PlatIngredient> listeBase, List<PlatIngredient> listeFinale)
        {
            // Boucle la liste de départ
            foreach (var PI in listeBase)
            {
                if (listeFinale.Contains(PI)) // Test si l'ingrédient est déjà présent dans la liste finale
                {
                    PlatIngredient oldPI = listeFinale.Find(pi => pi.IngredientPlat.Equals(PI.IngredientPlat)); // Retourne l'ingrédient de la liste finale

                    int index = listeFinale.FindIndex(0, pi => pi.IngredientPlat.Equals(PI.IngredientPlat)); // Retourne la position de l'ingrédient dans la liste finale
                    listeFinale.RemoveAt(index); // Supprime l'ingrédient de la liste finale

                    // Ajoute l'ingrédient dans la liste finale, avec la nouvelle quantité
                    listeFinale.Add(new PlatIngredient(PI.IngredientPlat, (oldPI.Quantite + PI.Quantite)));
                }

                else
                {
                    listeFinale.Add(PI); // Ajoute l'ingrédient dans la liste finale
                }
            }

            return listeFinale;
        }

        /// <summary>
        /// Permet de récupérer la liste des plats d'une réservation, en fonction de sa formule
        /// </summary>
        /// <param name="reservation">La réservation</param>
        /// <returns>Liste des plats, en fonction de la formule</returns>
        private async Task<List<Plat>> GetPlatsReservation(Reservation reservation)
        {
            List<Plat> platsReservation = new();

            bool[] formule = GestionFormule(reservation); // La formule de la réservation
            Menu menu = await _restaurationService.GetMenuAsync((int)reservation.Menu.IdMenu); // Le menu de la réservation

            // Boucle les plats du menu
            foreach (var platMenu in menu.Plats)
            {
                if (formule[0] == true && platMenu.TypePlat == "Entrée") // Test si la formule comprend une entrée, et si le plat est une entrée
                {
                    platsReservation.Add(await _restaurationService.GetPlatAsync((int)platMenu.IdPlat));
                }

                else if (formule[1] == true && platMenu.TypePlat == "Plat") // Test si la formule comprend un plat chaud, et si le plat est un plat chaud
                {
                    platsReservation.Add(await _restaurationService.GetPlatAsync((int)platMenu.IdPlat));
                }

                else if (formule[2] == true && platMenu.TypePlat == "Dessert") // Test si la formule comprend un dessert, et si le plat est un dessert
                {
                    platsReservation.Add(await _restaurationService.GetPlatAsync((int)platMenu.IdPlat));
                }
            }

            return platsReservation;
        }

        /// <summary>
        /// Permet de récupérer la liste des ingrédients d'un plat, en multipliant sa quantité par un multiplicateur
        /// </summary>
        /// <param name="plat">Le plat commandé</param>
        /// <param name="multiplicateur">Nombre de personne ayant commandé ce plat</param>
        /// <returns>Liste des ingrédients, et les quantités</returns>
        private async Task<List<PlatIngredient>> GetIngredientsPlatAsync(Plat plat, int multiplicateur)
        {
            List<PlatIngredient> ingredients = new();

            // Boucle les ingrédients du plat
            foreach (var platIngredient in plat.PlatIngredients)
            {
                Ingredient ingredient = await _restaurationService.GetIngredientAsync((int)platIngredient.IngredientPlat.IdIngredient); // Recupère l'ingrédient
                int quantite = platIngredient.Quantite * multiplicateur; // Multiplie sa quantité

                ingredients.Add(new PlatIngredient(ingredient, quantite)); // Ajoute l'ingrédient à la liste, avec sa nouvelle quantité
            }

            return ingredients;
        }
    }
}
