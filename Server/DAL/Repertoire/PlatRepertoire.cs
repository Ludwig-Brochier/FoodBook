using BO.DTO.Modeles;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repertoire
{
    class PlatRepertoire : IPlatRepertoire
    {
        private readonly IDbSession _session;
        public PlatRepertoire(IDbSession session)
        {
            _session = session;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            // Requete SQL pour supprimer le plat
            string requete = @"DELETE FROM Plat WHERE IdPlat = @ID";            
            
            return await _session.Connection.ExecuteAsync(requete, param: new { ID = id }, _session.Transaction) > 0; 
        }

        public async Task<ReponsePagination<Plat>> GetAllPlatsAsync(RequeteFiltresPlats requeteFiltresPlats)
        {
            string jointure = "";
            string where = "";

            if (requeteFiltresPlats.IdIngredient != 0)
            {
                jointure = "inner JOIN PlatIngredient ON Plat.IdPlat = PlatIngredient.IdPlat";
                where = @"WHERE IdIngredient = @IdIngredient";
            }

            if (requeteFiltresPlats.Type != null)
            {
                if (requeteFiltresPlats.Type == "entree")
                {
                    requeteFiltresPlats.Type = "entrée";
                }
                where = @"WHERE TypePlat = @Type";
            }

            string requete = @$"SELECT * FROM Plat
                                {jointure}
                                {where}
                                ORDER BY Plat.IdPlat
                                OFFSET @TaillePage * (@Page - 1) rows
                                FETCH NEXT @TaillePage rows only";
            
            string requeteNbPlat = $"SELECT COUNT(*) FROM Plat {jointure} {where}";

            
            List<Plat> plats = await _session.Connection.QueryAsync<Plat>(requete, requeteFiltresPlats, _session.Transaction) as List<Plat>;
            
            int nbPlat = await _session.Connection.ExecuteScalarAsync<int>(requeteNbPlat, requeteFiltresPlats, _session.Transaction);

            return new ReponsePagination<Plat>(requeteFiltresPlats.Page, requeteFiltresPlats.TaillePage, nbPlat, plats);
        }

        public async Task<ReponsePagination<PlatPopulaire>> GetAllPlatsPopulaireAsync(RequeteFiltresPlats requeteFiltresPlats)
        {
            string requete = @"SELECT 
                                    SUM(NbPersonne) AS NbReservations,                                    
                                    Plat.IdPlat,
	                                Plat.Intitule,
	                                Plat.TypePlat,
	                                Prix	                                
                                FROM Reservation
                                    inner JOIN Formule ON Reservation.IdFormule = Formule.IdFormule	
                                    inner JOIN MenuPlat ON Reservation.IdMenu = MenuPlat.IdMenu
                                    inner JOIN Plat ON MenuPlat.IdPlat = Plat.IdPlat
                                WHERE SUBSTRING(Formule.Intitule, 1, 3) = SUBSTRING(Plat.TypePlat, 1, 3)
                                    or SUBSTRING(Formule.Intitule, 8, 3) = SUBSTRING(Plat.TypePlat, 1, 3)
                                    or SUBSTRING(Formule.Intitule, 6, 3) = SUBSTRING(Plat.TypePlat, 1, 3)
                                    or SUBSTRING(Formule.Intitule, 13, 3) = SUBSTRING(Plat.TypePlat, 1, 3)	
                                GROUP BY Plat.IdPlat, Plat.Intitule, TypePlat, Prix
                                ORDER BY NbReservations DESC
                                OFFSET @taillePage * (@page - 1) rows
                                FETCH NEXT @taillePage rows only";
            string requeteNbPlat = "SELECT COUNT(*) FROM Plat";

            List<PlatPopulaire> plats = await _session.Connection.QueryAsync<PlatPopulaire, Plat, PlatPopulaire>(requete, (platPopulaire, plat) =>
            {
                platPopulaire.Plat = plat;
                return platPopulaire;
            }, requeteFiltresPlats, _session.Transaction, splitOn:"idPlat") as List<PlatPopulaire>;
            int nbPlat = await _session.Connection.ExecuteScalarAsync<int>(requeteNbPlat, null, _session.Transaction);

            return new ReponsePagination<PlatPopulaire>(requeteFiltresPlats.Page, requeteFiltresPlats.TaillePage, nbPlat, plats);
        }

        public async Task<Plat> GetAsync(int id)
        {
            // Requete SQL pour récupérer le plat demandé
            string requete = @"SELECT * FROM Plat WHERE IdPlat = @ID";  

            // Le plat demandé
            Plat plat = await _session.Connection.QueryFirstOrDefaultAsync<Plat>(requete, param: new { ID = id }, _session.Transaction);

            if (plat != null)
            {
                string requetePlatIngredient = @"SELECT * FROM PlatIngredient
                                                     inner JOIN Ingredient ON PlatIngredient.IdIngredient = Ingredient.IdIngredient
                                                  WHERE IdPlat = @ID";

                plat.PlatIngredients = await _session.Connection.QueryAsync<PlatIngredient, Ingredient, PlatIngredient>(requetePlatIngredient, (platInregient, ingredient) =>
                {
                    platInregient.IngredientPlat = ingredient;
                    return platInregient;
                },param: new { ID = id }, _session.Transaction, splitOn:"idIngredient") as List<PlatIngredient>;
            }

            return plat;
        }

        public async Task<Plat> InsertAsync(Plat entite)
        {
            // Requete SQL pour insérer un nouveau plat
            string requete = @"INSERT INTO Plat(Intitule, TypePlat, Prix) OUTPUT INSERTED.IdPlat VALUES(@intitule, @typePlat, @prix)";
            // L'identifiant du plat généré automatiquement par la base de données, en retour de la requete SQL
            int idPlat = await _session.Connection.QuerySingleAsync<int>(requete, entite, _session.Transaction);
            
            // Liste des ingrédients et leur quantité
            List<PlatIngredient> platIngredients = entite.PlatIngredients; 

            // Requete pour insérer les ingrédients du nouveau plat
            string requetePlatIngredients = @"INSERT INTO PlatIngredient(IdPlat, IdIngredient, Quantite) VALUES(@idPlat, @idIngredient, @quantite)";

            // Boucle les ingrédients
            foreach (var platIngredient in platIngredients)
            {
                // Insère les ingrédients du nouveau plat dans la table d'association PlatIngredient
                await _session.Connection.QueryAsync(requetePlatIngredients, 
                        param: new { idPlat, platIngredient.IngredientPlat.IdIngredient, platIngredient.Quantite },
                        _session.Transaction);
            }            

            return await GetAsync(idPlat);
        }

        public async Task<Plat> UpdateAsync(Plat entite)
        {
            // Requete SQL pour mettre à jour un plat
            string requete = @"UPDATE Plat SET Intitule = @intitule, TypePlat = @typePlat, Prix = @prix WHERE IdPlat = @idPlat";

            // Test si le plat à mettre à jour contient des ingrédients à mettre à jour dans la table d'association PlatIngredient
            if (entite.PlatIngredients != null)
            {
                // Requete SQL pour supprimer les anciens ingrédients du plat
                string requeteDelete = @"DELETE FROM PlatIngredient WHERE IdPlat = @idPlat";
                // Requete SQL pour ajouter les nouveaux ingrédients du plat
                string requeteInsert = @"INSERT INTO PlatIngredient(IdPlat, IdIngredient, Quantite) VALUES (@idPlat, @idIngredient, @quantite)";

                // Supprime les ingrédients
                await _session.Connection.ExecuteAsync(requeteDelete, entite, _session.Transaction);

                // Liste des ingrédients et leur quantité
                List<PlatIngredient> platIngredients = entite.PlatIngredients;

                // Boucle la liste des ingrédients
                foreach (var platIngredient in platIngredients)
                {
                    // Insère les ingrédients du plat à mettre à jour dans la table d'association PlatIngredient
                    await _session.Connection.QueryAsync(requeteInsert,
                            param: new { entite.IdPlat, platIngredient.IngredientPlat.IdIngredient, platIngredient.Quantite },
                            _session.Transaction);
                }
            }

            // Si la mise à jour du plat fonctionne
            if (await _session.Connection.ExecuteAsync(requete, entite, _session.Transaction) > 0)
            {                
                return await GetAsync((int)entite.IdPlat);
            }
            else
            {
                return null;
            }
            
        }
    }
}
