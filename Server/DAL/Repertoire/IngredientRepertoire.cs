using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repertoire
{    
    class IngredientRepertoire : IIngredientRepertoire
    {
        private readonly IDbSession _session;
        public IngredientRepertoire(IDbSession session)
        {
            _session = session;
        }


        public async Task<ReponsePagination<Ingredient>> GetAllAsync(RequetePagination requetePagination)
        {
            var requete = @"SELECT * FROM Ingredient
                            ORDER BY IdIngredient
                            OFFSET @TaillePage * (@Page - 1) rows
                            FETCH NEXT @TaillePage rows only";
            string requeteNbIngredient = "SELECT COUNT(*) FROM Ingredient";

            List<Ingredient> ingredients = await _session.Connection.QueryAsync<Ingredient>(requete, requetePagination, _session.Transaction) as List<Ingredient>;
            int nbIngredient = await _session.Connection.ExecuteScalarAsync<int>(requeteNbIngredient, null, _session.Transaction);

            return new ReponsePagination<Ingredient>(requetePagination.Page, requetePagination.TaillePage, nbIngredient, ingredients);
        }

        public async Task<Ingredient> GetAsync(int id)
        {
            var requete = @"SELECT * FROM Ingredient WHERE IdIngredient = @ID";

            return await _session.Connection.QueryFirstOrDefaultAsync<Ingredient>(requete, param: new { ID = id }, _session.Transaction);
        }

        public async Task<ReponsePeriodique<PlatIngredient>> GetCommandeIngredientsAsync(RequetePeriodique requetePeriodique)
        {
            string requete = @"SELECT 
                                    PlatIngredient.IdIngredient,
	                                SUM(PlatIngredient.Quantite * NbPersonne) AS Quantite,
	                                Ingredient.IdIngredient,                                    
	                                Ingredient.Intitule,
	                                Ingredient.Prix                                                                        
                                FROM (SELECT 
                                        IdReservation, 
                                        NbPersonne, 
                                        Reservation.IdMenu, 
                                        Reservation.IdFormule 
                                        FROM Reservation 
                                            inner JOIN menu ON Reservation.IdMenu = Menu.IdMenu  
                                        WHERE DteMenu BETWEEN @debut AND @fin) ReservationMenu
                                    inner JOIN Formule ON ReservationMenu.IdFormule = Formule.IdFormule	
                                    inner JOIN MenuPlat ON ReservationMenu.IdMenu = MenuPlat.IdMenu
                                    inner JOIN Plat ON MenuPlat.IdPlat = Plat.IdPlat
                                    inner JOIN PlatIngredient ON Plat.IdPlat = PlatIngredient.IdPlat
                                    inner JOIN Ingredient ON PlatIngredient.IdIngredient = Ingredient.IdIngredient
                                WHERE SUBSTRING(Formule.Intitule, 1, 3) = SUBSTRING(Plat.TypePlat, 1, 3)
                                    or SUBSTRING(Formule.Intitule, 8, 3) = SUBSTRING(Plat.TypePlat, 1, 3)
                                    or SUBSTRING(Formule.Intitule, 6, 3) = SUBSTRING(Plat.TypePlat, 1, 3)
                                    or SUBSTRING(Formule.Intitule, 13, 3) = SUBSTRING(Plat.TypePlat, 1, 3)
                                GROUP BY Ingredient.IdIngredient, Ingredient.Intitule, Ingredient.Prix, PlatIngredient.IdIngredient
                                ORDER BY Ingredient.IdIngredient OFFSET @taillePage * (@page-1) rows
                                FETCH NEXT @taillePage rows only";

            List<PlatIngredient> commande = await _session.Connection.QueryAsync<PlatIngredient, Ingredient, PlatIngredient>(requete, (platIngredient, ingredient) => 
            {
                platIngredient.IngredientPlat = ingredient;
                return platIngredient;
            }, requetePeriodique, _session.Transaction, splitOn:"idIngredient") as List<PlatIngredient>;

            return new ReponsePeriodique<PlatIngredient>(requetePeriodique.Debut, requetePeriodique.Fin, requetePeriodique.Page, requetePeriodique.TaillePage, commande.Count, commande);
        }
    }
}
