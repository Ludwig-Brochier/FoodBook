using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var requete = @"DELETE FROM Plat WHERE IdPlat = @ID";            
            // Requete SQL pour vérifier le nombre de lignes dans la table d'association PlatIngredient
            var requeteExist = @"SELECT COUNT(*) FROM PlatIngredient WHERE IdPlat = @ID"; // Normalement suppérieur à 0

            if (await _session.Connection.ExecuteScalarAsync<int>(requeteExist, param: new { ID = id }, _session.Transaction) > 0)
            {
                // Requete SQL pour supprimer le plat dans la table d'association PlatIngredient
                var requetePlatIngredient = @"DELETE FROM PlatIngredient WHERE IdPlat = @ID";

                // Supprimer les entrées correspondante au plat dans la table PlatIngredient
                await _session.Connection.ExecuteAsync(requetePlatIngredient, param: new { ID = id }, _session.Transaction);
            }

            return await _session.Connection.ExecuteAsync(requete, param: new { ID = id }, _session.Transaction) > 0; 
        }

        public async Task<ReponsePagination<Plat>> GetAllAsync(RequetePagination requetePagination)
        {
            // Requete SQL pour récupérer une liste de plat paginés
            var requeteTask = @"SELECT * FROM Plat
                                ORDER BY IdPlat
                                OFFSET @TaillePage * (@Page - 1) rows
                                FETCH NEXT @TaillePage rows only";
            // Requete SQL pour récupérer le nombre de plat présent dans la base de données
            var requeteNbPlat = "SELECT COUNT(*) FROM Plat";

            // Récupère la liste des plats
            IEnumerable<Plat> taskPlat = await _session.Connection.QueryAsync<Plat>(requeteTask, requetePagination, _session.Transaction);
            // Recupère le nombre de plat total
            int nbPlat = await _session.Connection.ExecuteScalarAsync<int>(requeteNbPlat, null, _session.Transaction);

            return new ReponsePagination<Plat>(requetePagination.Page, requetePagination.TaillePage, nbPlat, taskPlat.ToList());
        }

        public async Task<Plat> GetAsync(int id)
        {
            // Requete SQL pour récupérer le plat demandé
            var requete = @"SELECT * FROM Plat WHERE IdPlat = @ID";  

            // Le plat demandé
            Plat plat = await _session.Connection.QueryFirstOrDefaultAsync<Plat>(requete, param: new { ID = id }, _session.Transaction);

            if (plat != null)
            {
                // Requete SQL pour récupérer les ingrédients du plat demandé
                var requeteIngredient = @"SELECT Ingredient.IdIngredient, Ingredient.Intitule, Ingredient.Prix FROM Plat 
                                            JOIN PlatIngredient ON Plat.IdPLat = PlatIngredient.IdPlat
                                            JOIN Ingredient ON PlatIngredient.IdIngredient = Ingredient.IdIngredient
                                            WHERE Plat.IdPlat = @ID";
                // Requete SQL pour récupérer la quantité des ingrédients du plat demandé
                var requeteQuantite = @"SELECT Quantite FROM PlatIngredient WHERE IdIngredient = @IdIngredient AND IdPlat = @IdPlat";

                // La liste des ingrédients du plat
                List<Ingredient> ingredients = (List<Ingredient>)await _session.Connection.QueryAsync<Ingredient>(requeteIngredient, param: new { ID = id }, _session.Transaction);

                // Instanciation d'une liste de PlatIngredient représentant les ingrédients du plat
                List<PlatIngredient> platIngredients = new();

                // Boucle la liste des ingrédients du plat
                foreach (var ingredient in ingredients)
                {
                    // Quantité de l'ingrédient en question
                    int quantite = await _session.Connection.QueryFirstOrDefaultAsync<int>(requeteQuantite, param: new { ingredient.IdIngredient, IdPlat = id }, _session.Transaction);
                    // Ajoute l'ingrédient du plat et sa quantité à la liste de PlatIngredient
                    platIngredients.Add(new PlatIngredient(ingredient, quantite));
                }

                // Passe la liste des ingrédients et leur quantité au plat
                plat.PlatIngredients = platIngredients;
            }            

            return plat;
        }

        public async Task<Plat> InsertAsync(Plat entite)
        {
            // Requete SQL pour insérer un nouveau plat
            var requete = @"INSERT INTO Plat(Intitule, TypePlat, Prix) OUTPUT INSERTED.IdPlat VALUES(@intitule, @typePlat, @prix)";
            // L'identifiant du plat généré automatiquement par la base de données, en retour de la requete SQL
            int idPlat = await _session.Connection.QuerySingleAsync<int>(requete, entite, _session.Transaction);

            // Liste des ingrédients et leur quantité
            List<PlatIngredient> platIngredients = entite.PlatIngredients; 

            // Requete pour insérer les ingrédients du nouveau plat
            var requetePlatIngredients = @"INSERT INTO PlatIngredient(IdPlat, IdIngredient, Quantite) VALUES(@idPlat, @idIngredient, @quantite)";

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
            var requete = @"UPDATE Plat SET Intitule = @intitule, TypePlat = @typePlat, Prix = @prix WHERE IdPlat = @idPlat";

            // Test si le plat à mettre à jour contient des ingrédients à mettre à jour dans la table d'association PlatIngredient
            if (entite.PlatIngredients.Count > 0)
            {
                // Requete SQL pour supprimer les anciens ingrédients du plat
                var requeteDelete = @"DELETE FROM PlatIngredient WHERE IdPlat = @idPlat";
                // Requete SQL pour ajouter les nouveaux ingrédients du plat
                var requeteInsert = @"INSERT INTO PlatIngredient(IdPlat, IdIngredient, Quantite) VALUES (@idPlat, @idIngredient, @quantite)";

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
