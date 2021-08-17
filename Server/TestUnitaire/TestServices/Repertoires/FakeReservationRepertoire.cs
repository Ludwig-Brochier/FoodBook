using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using DAL.Repertoire;

namespace TestUnitaire.TestServices.Repertoires
{
    public class FakeReservationRepertoire : IReservationRepertoire
    {
        public List<Reservation> reservations = new()
        {
            new Reservation(1, "test", "test", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
            new Reservation(2, "test", "test", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
            new Reservation(3, "test", "test", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
            new Reservation(4, "test", "test", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
            new Reservation(5, "test", "test", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")),
        };

        public Task<bool> DeleteAsync(int id)
        {
            int i = reservations.RemoveAll(r => r.IdReservation == id);
            return Task.FromResult(i > 0);
        }

        public Task<ReponsePeriodique<Reservation>> GetAllPeriodeAsync(RequetePeriodique requetePeriodique)
        {
            List<Reservation> data = null;

            if (requetePeriodique.Page * requetePeriodique.TaillePage < reservations.Count)
            {
                int firstIndex = (requetePeriodique.Page - 1) * requetePeriodique.TaillePage;
                int lastIndex = ((requetePeriodique.Page - 1) * requetePeriodique.TaillePage) + requetePeriodique.TaillePage;
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

        public Task<Reservation> GetAsync(int id)
        {
            if (id == 10)
            {
                return Task.FromResult<Reservation>(null);
            }

            else
            {
                return Task.FromResult(reservations.Find(r => r.IdReservation == id));
            }
        }

        public Task<Reservation> InsertAsync(Reservation entite)
        {
            if (entite.Menu.IdMenu == 10)
            {
                return Task.FromResult<Reservation>(null);
            }

            if (entite.Formule.IdFormule == 10)
            {
                return Task.FromResult<Reservation>(null);
            }

            return Task.FromResult(entite);
        }

        public Task<Reservation> UpdateAsync(Reservation entite)
        {
            if (entite.Menu.IdMenu == 10)
            {
                return Task.FromResult<Reservation>(null);
            }

            if (entite.Formule.IdFormule == 10)
            {
                return Task.FromResult<Reservation>(null);
            }

            Reservation newReservation = reservations.Find(r => r.IdReservation == entite.IdReservation);
            newReservation.Nom = entite.Nom;
            newReservation.Prenom = entite.Prenom;
            newReservation.NumTel = entite.NumTel;
            newReservation.NbPersonne = entite.NbPersonne;
            newReservation.Menu = entite.Menu;
            newReservation.Formule = entite.Formule;

            return Task.FromResult(newReservation);
        }
    }
}
