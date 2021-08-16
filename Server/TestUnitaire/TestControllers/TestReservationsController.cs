using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using API.Controllers;
using TestUnitaire.TestControllers.Services;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using BO.DTO.Requetes;
using BO.Entite;

namespace TestUnitaire.TestControllers
{
    public class TestReservationsController
    {
        [Fact]
        public async void TestGetReservationAsync()
        {
            //Arrange
            IReservationService reservationService = new FakeReservationService();
            ReservationsController reservationsController = new ReservationsController(reservationService);

            //Acts
            var resultOK = await reservationsController.GetReservationAsync(1) as OkObjectResult;
            var resultNotFound = await reservationsController.GetReservationAsync(10) as NotFoundResult;

            //Asserts
            Assert.NotNull(resultOK);
            Assert.Equal(200, resultOK.StatusCode);
            Assert.NotNull(resultNotFound);
            Assert.Equal(404, resultNotFound.StatusCode);
        }

        [Fact]
        public async void TestGetAllReservationsAsync()
        {
            //Arrange
            IReservationService reservationService = new FakeReservationService();
            ReservationsController reservationsController = new ReservationsController(reservationService);

            //Acts
            var resultOK = await reservationsController.GetAllReservationsAsync(new RequetePeriodique(DateTime.Today, DateTime.Today.AddDays(7), 1, 3));

            //Asserts
            Assert.NotNull(resultOK);
        }

        [Fact]
        public async void TestDeleteReservationAsync()
        {
            //Arrange
            IReservationService reservationService = new FakeReservationService();
            ReservationsController reservationsController = new ReservationsController(reservationService);

            //Acts
            var resultOK = await reservationsController.DeleteReservationAsync(1) as NoContentResult;
            var resultNotFound = await reservationsController.DeleteReservationAsync(10) as NotFoundResult;

            //Asserts
            Assert.NotNull(resultOK);
            Assert.Equal(204, resultOK.StatusCode);
            Assert.NotNull(resultNotFound);
            Assert.Equal(404, resultNotFound.StatusCode);
        }

        [Fact]
        public async void TestInsertReservationAsync()
        {
            //Arrange
            IReservationService reservationService = new FakeReservationService();
            ReservationsController reservationsController = new ReservationsController(reservationService);
            Reservation testReservation = new Reservation(1, "test Insert", "test Insert", "+33 6 52 35 15 82", 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée"));
            //Acts
            var resultOK = await reservationsController.InsertReservationAsync(testReservation) as CreatedAtActionResult;
            var resultBadRequest = await reservationsController.InsertReservationAsync(null) as BadRequestResult;

            //Asserts
            Assert.NotNull(resultOK);
            Assert.Equal(201, resultOK.StatusCode);
            Assert.NotNull(resultBadRequest);
            Assert.Equal(400, resultBadRequest.StatusCode);
        }

        [Fact]
        public async void TestUpdateReservationAsync()
        {
            //Arrange
            IReservationService reservationService = new FakeReservationService();
            ReservationsController reservationsController = new ReservationsController(reservationService);
            Reservation testReservation = new Reservation(1, "test Update", "test Update", "+33 6 52 35 15 82", 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée"));
            Reservation testReservationNotFound = new Reservation(10, "test Update", "test Update", "+33 6 52 35 15 82", 4, new Menu(1, DateTime.Today, true, null), new Formule(1, "Entrée"));

            //Acts
            var resultOK = await reservationsController.UpdateReservationAsync(1, testReservation) as OkObjectResult;
            var resultBadId = await reservationsController.UpdateReservationAsync(2, testReservation) as BadRequestResult;
            var resultReservationNull = await reservationsController.UpdateReservationAsync(1, null) as BadRequestResult;
            var resultNotFound = await reservationsController.UpdateReservationAsync(10, testReservationNotFound) as NotFoundResult;

            //Asserts
            Assert.NotNull(resultOK);
            Assert.Equal(200, resultOK.StatusCode);
            Assert.NotNull(resultBadId);
            Assert.Equal(400, resultBadId.StatusCode);
            Assert.NotNull(resultReservationNull);
            Assert.Equal(400, resultReservationNull.StatusCode);
            Assert.NotNull(resultNotFound);
            Assert.Equal(404, resultNotFound.StatusCode);
        }
    }
}
