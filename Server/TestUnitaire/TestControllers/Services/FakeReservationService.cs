using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;

namespace TestUnitaire.TestControllers.Services
{
    public class FakeReservationService : IReservationService
    {
        public List<Reservation> reservations = new()
        {
            new Reservation(1, "test", "test", "+33 6 52 35 15 82", 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
            new Reservation(2, "test", "test", "+33 6 52 35 15 82", 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
            new Reservation(3, "test", "test", "+33 6 52 35 15 82", 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
            new Reservation(4, "test", "test", "+33 6 52 35 15 82", 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
            new Reservation(5, "test", "test", "+33 6 52 35 15 82", 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
        };

        public Task<bool> DeleteReservationAsync(int idReservation)
        {
            int i = reservations.RemoveAll(r => r.IdReservation == idReservation);
            return Task.FromResult(i > 0);
        }

        public Task<ReponsePeriodique<Reservation>> GetAllReservationsAsync(RequetePeriodique requetePeriodique)
        {
            List<Reservation> data = null;

            if (requetePeriodique.Page * requetePeriodique.TaillePage < reservations.Count)
            {
                int firstIndex = (requetePeriodique.Page - 1) * requetePeriodique.TaillePage;
                int lastIndex = ((requetePeriodique.Page - 1) * requetePeriodique.TaillePage) +requetePeriodique.TaillePage;
                Math.Clamp(lastIndex, 0, reservations.Count - 1);
                data = reservations.GetRange(firstIndex, lastIndex - firstIndex);
            }

            return Task.FromResult(new ReponsePeriodique<Reservation>()
            {
                Debut = requetePeriodique.Debut,
                Fin = requetePeriodique.Fin,
                Page = requetePeriodique.Page,
                TaillePage = requetePeriodique.TaillePage,
                TotalEnregistrements = reservations.Count,
                Donnees = data
            });
        }

        public Task<Reservation> GetReservationAsync(int idReservation)
        {
            if (idReservation == 10)
            {
                return Task.FromResult<Reservation>(null);
            }

            else
            {
                return Task.FromResult(reservations.Find(r => r.IdReservation == idReservation));
            }
        }

        public Task<Reservation> InsertReservationAsync(Reservation reservation)
        {
            return Task.FromResult(reservation);
        }

        public Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            if (reservation.IdReservation == 10)
            {
                return Task.FromResult<Reservation>(null);
            }

            Reservation newReservation = reservations.Find(r => r.IdReservation == reservation.IdReservation);
            newReservation.Nom = reservation.Nom;
            newReservation.Prenom = reservation.Prenom;
            newReservation.NumTel = reservation.NumTel;
            newReservation.NbPersonne = reservation.NbPersonne;
            newReservation.Menu = reservation.Menu;
            newReservation.Formule = reservation.Formule;

            return Task.FromResult(newReservation);
        }
    }
}
