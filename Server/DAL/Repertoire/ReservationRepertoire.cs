using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.UOW;
using Dapper;
using System.Collections.Generic;
using System.Linq;
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
            var requete = @"SELECT * FROM Reservation 
                            inner JOIN Menu ON Reservation.IdMenu = Menu.IdMenu
                            inner JOIN Formule ON Reservation.IdFormule = Formule.IdFormule
                            WHERE DteMenu >= @debut AND DteMenu <= @fin
                            ORDER BY IdReservation OFFSET @taillePage * (@page - 1) rows
                            FETCH NEXT @taillePage rows only";

            var requeteNbReservations = @"SELECT COUNT(*) FROM Reservation inner JOIN Menu ON Reservation.IdMenu = Menu.IdMenu WHERE DteMenu BETWEEN @debut AND @fin";

            List<Reservation> reservations = await _session.Connection.QueryAsync<Reservation, Menu, Formule, Reservation>(requete, (reservation, menu, formule) => 
            {
                reservation.Menu = menu;
                reservation.Formule = formule;
                return reservation;
            }, requetePeriodique, _session.Transaction, splitOn: "idMenu, idFormule") as List<Reservation>;
            int nbReservations = await _session.Connection.ExecuteScalarAsync<int>(requeteNbReservations, requetePeriodique, _session.Transaction);

            return new ReponsePeriodique<Reservation>(requetePeriodique.Debut, requetePeriodique.Fin, requetePeriodique.Page, requetePeriodique.TaillePage, nbReservations, reservations);
        }

        public async Task<Reservation> GetAsync(int id)
        {
            var requete = @"SELECT * FROM Reservation 
                            inner JOIN Menu ON Reservation.IdMenu = Menu.IdMenu
                            inner JOIN Formule ON Reservation.IdFormule = Formule.IdFormule
                            WHERE IdReservation = @ID";

            List<Reservation> reservations = await _session.Connection.QueryAsync<Reservation, Menu, Formule, Reservation>(requete, (reservation, menu, formule) =>
            {
                reservation.Menu = menu;
                reservation.Formule = formule;
                return reservation;
            }, param: new { ID = id }, _session.Transaction, splitOn: "idMenu, idFormule") as List<Reservation>;

            return reservations.FirstOrDefault();
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
