using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TestUnitaire.TestServices.Repertoires;
using DAL.Repertoire;
using BO.DTO.Requetes;
using BO.Entite;

namespace TestUnitaire.TestServices
{
    public class TestReservationsService
    {
        [Fact]
        public async void TestGetAsync()
        {
            //Arrange
            IReservationRepertoire reservationRepertoire = new FakeReservationRepertoire();

            //Acts
            var resultOK = await reservationRepertoire.GetAsync(1);

            //Asserts
            Assert.NotNull(resultOK);
        }

        [Fact]
        public async void TestGetAllPeriodeAsync()
        {
            //Arrange
            IReservationRepertoire reservationRepertoire = new FakeReservationRepertoire();

            //Acts
            var resultOK = await reservationRepertoire.GetAllPeriodeAsync(new RequetePeriodique(DateTime.Today, DateTime.Today.AddDays(7), 1, 3));

            //Asserts
            Assert.NotNull(resultOK);
        }

        [Fact]
        public async void TestDeleteAsync()
        {
            //Arrange
            IReservationRepertoire reservationRepertoire = new FakeReservationRepertoire();

            //Acts
            var resultOK = await reservationRepertoire.DeleteAsync(1);
            var resultNotOK = await reservationRepertoire.DeleteAsync(10);

            //Asserts
            Assert.True(resultOK);
            Assert.False(resultNotOK);
        }

        [Fact]
        public async void TestInsertAsync()
        {
            //Arrange
            IReservationRepertoire reservationRepertoire = new FakeReservationRepertoire();

            //Acts
            var resultOK = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")));
            var resultBadNom = await reservationRepertoire.InsertAsync(new Reservation(1, "", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")));
            var resultBadNbPersonne = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 10, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")));
            var resultBadMenu = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(10, DateTime.Today, true, null), new Formule(1, "Entrée")));
            var resultBadFormule = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(10, "Entrée")));
            var resultBadDteButoire = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today.AddDays(-10), true, null), new Formule(1, "Entrée")));

            //Asserts
            Assert.NotNull(resultOK);
            Assert.NotNull(resultBadNom);
            Assert.NotNull(resultBadNbPersonne);
            Assert.Null(resultBadMenu);
            Assert.Null(resultBadFormule);
            Assert.NotNull(resultBadDteButoire);
        }

        [Fact]
        public async void TestUpdateAsync()
        {
            //Arrange
            IReservationRepertoire reservationRepertoire = new FakeReservationRepertoire();

            //Acts
            var resultOK = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")));
            var resultBadNom = await reservationRepertoire.InsertAsync(new Reservation(1, "", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")));
            var resultBadNbPersonne = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 10, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée")));
            var resultBadMenu = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(10, DateTime.Today, true, null), new Formule(1, "Entrée")));
            var resultBadFormule = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today, true, null), new Formule(10, "Entrée")));
            var resultBadDteButoire = await reservationRepertoire.InsertAsync(new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", DateTime.Today, 4, new Menu(1, DateTime.Today.AddDays(-10), true, null), new Formule(1, "Entrée")));

            //Asserts
            Assert.NotNull(resultOK);
            Assert.NotNull(resultBadNom);
            Assert.NotNull(resultBadNbPersonne);
            Assert.Null(resultBadMenu);
            Assert.Null(resultBadFormule);
            Assert.NotNull(resultBadDteButoire);
        }
    }
}
