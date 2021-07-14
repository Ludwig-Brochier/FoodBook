using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using Dapper;
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
            var requete = @"DELETE FROM Plat WHERE IdPlat = @ID";            
            
            return await _session.Connection.ExecuteAsync(requete, param: new { ID = id }, _session.Transaction) > 0; 
        }

        public async Task<ReponsePagination<Plat>> GetAllAsync(RequetePagination requetePagination)
        {
            // Requete SQL pour récupérer une liste de plat paginés
            var requete = @"SELECT * FROM Plat
                                ORDER BY IdPlat
                                OFFSET @TaillePage * (@Page - 1) rows
                                FETCH NEXT @TaillePage rows only";
            // Requete SQL pour récupérer le nombre de plat présent dans la base de données
            var requeteNbPlat = "SELECT COUNT(*) FROM Plat";

            // Récupère la liste des plats
            List<Plat> plats = await _session.Connection.QueryAsync<Plat>(requete, requetePagination, _session.Transaction) as List<Plat>;
            // Recupère le nombre de plat total
            int nbPlat = await _session.Connection.ExecuteScalarAsync<int>(requeteNbPlat, null, _session.Transaction);

            return new ReponsePagination<Plat>(requetePagination.Page, requetePagination.TaillePage, nbPlat, plats);
        }

        public async Task<Plat> GetAsync(int id)
        {
            // Requete SQL pour récupérer le plat demandé
            var requete = @"SELECT * FROM Plat WHERE IdPlat = @ID";  

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
