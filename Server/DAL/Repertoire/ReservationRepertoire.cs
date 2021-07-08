using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repertoire
{
    class ReservationRepertoire : IReservationRepertoire
    {
        private readonly IDbSession _session;
        public ReservationRepertoire(IDbSession session)
        {
            _session = session;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var requete = @"DELETE FROM Reservation WHERE IdReservation = @ID";

            return await _session.Connection.ExecuteAsync(requete, param: new { ID = id }, _session.Transaction) > 0;
        }

        public async Task<ReponsePeriodique<Reservation>> GetAllPeriodeAsync(RequetePeriodique requetePeriodique)
        {
            var requete = @"SELECT IdReservation FROM Reservation 
                            JOIN Menu ON Reservation.IdMenu = Menu.IdMenu 
                            WHERE DteMenu BETWEEN @debut AND @fin
                            ORDER BY IdReservation OFFSET @taillePage * (@page - 1) rows 
                            FETCH NEXT @taillePage rows only";
            var requeteNbReservations = @"SELECT COUNT(*) FROM Reservation JOIN Menu ON Reservation.IdMenu = Menu.IdMenu WHERE DteMenu BETWEEN @debut AND @fin";

            List<int> idReservations = await _session.Connection.QueryAsync<int>(requete, requetePeriodique, _session.Transaction) as List<int>;
            int nbReservations = await _session.Connection.ExecuteScalarAsync<int>(requeteNbReservations, requetePeriodique, _session.Transaction);

            List<Reservation> reservations = new();
            foreach (var id in idReservations)
            {
                reservations.Add(await GetAsync(id));
            }

            return new ReponsePeriodique<Reservation>(requetePeriodique.Debut, requetePeriodique.Fin, requetePeriodique.Page, requetePeriodique.TaillePage, nbReservations, reservations);
        }

        public async Task<Reservation> GetAsync(int id)
        {
            var requete = @"SELECT * FROM Reservation WHERE IdReservation = @ID";

            Reservation reservation = await _session.Connection.QueryFirstOrDefaultAsync<Reservation>(requete, param: new { ID = id }, _session.Transaction);

            if (reservation != null)
            {
                var requeteFormule = @"SELECT * FROM Formule 
                                        JOIN Reservation ON Formule.IdFormule = Reservation.IdFormule 
                                        WHERE IdReservation = @ID";
                var requeteMenu = @"SELECT * FROM Menu 
                                    JOIN Reservation ON Menu.IdMenu = Reservation.IdMenu 
                                    WHERE IdReservation = @ID";

                reservation.Formule = await _session.Connection.QueryFirstOrDefaultAsync<Formule>(requeteFormule, param: new { ID = id }, _session.Transaction);
                reservation.Menu = await _session.Connection.QueryFirstOrDefaultAsync<Menu>(requeteMenu, param: new { ID = id }, _session.Transaction);
            }

            return reservation;         
        }

        public async Task<Reservation> InsertAsync(Reservation entite)
        {
            var requete = @"INSERT INTO Reservation(Nom, Prenom, NumTel, NbPersonne, IdFormule, IdMenu) OUTPUT INSERTED.IdReservation 
                            VALUES(@nom, @prenom, @numTel, @nbPersonne, @idFormule, @idMenu)";

            int idReservation = await _session.Connection.QuerySingleAsync<int>(requete, param: new { 
                entite.Nom, entite.Prenom, entite.NumTel, entite.NbPersonne, entite.Formule.IdFormule, entite.Menu.IdMenu 
            }, _session.Transaction);

            return await GetAsync(idReservation);
        }

        public async Task<Reservation> UpdateAsync(Reservation entite)
        {
            var requete = @"UPDATE Reservation SET 
                                Nom = @nom, 
                                Prenom = @prenom, 
                                NumTel = @numTel, 
                                NbPersonne = @nbPersonne, 
                                IdFormule = @idFormule, 
                                IdMenu = @idMenu 
                            WHERE IdReservation = @idReservation";

            if (await _session.Connection.ExecuteAsync(requete, param: new { 
                        entite.Nom, entite.Prenom, entite.NumTel, entite.NbPersonne, entite.Formule.IdFormule, entite.Menu.IdMenu, entite.IdReservation
                        }, _session.Transaction) > 0 )
            {
                return await GetAsync((int)entite.IdReservation);
            }
            else
            {
                return null;
            }
        }
    }
}
