using API;
using BO.Entite;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TestIntegration.Fixtures;
using Xunit;
using BO.DTO.Reponses;
using System.Net;

namespace TestIntegration
{
    public class ReservationsControllerTestIntegration : IntegrationTest
    {
        public ReservationsControllerTestIntegration(WebApplicationFactory<Startup> factory) : base(factory) { }
        
        [Fact]
        public async Task GetAllReservationsAsync_Should_Be_OK()
        {
            //Arrange
            List<Reservation> reservations = new()
            {
                new Reservation(1, "cuvier", "elie", "+33 6 44 63 71 11", new DateTime(2021, 08, 23), 1, new Menu(1, DateTime.Today, true, null), new Formule(1, null)),
                new Reservation(2, "deloffre", "dimitri", "+33 7 53 53 39 67", new DateTime(2021, 08, 27), 2, new Menu(10, DateTime.Today, true, null), new Formule(7, null)),
                new Reservation(3, "lussier", "sigolène", "+33 6 52 35 15 82", new DateTime(2021, 08, 27), 4, new Menu(6, DateTime.Today, true, null), new Formule(6, null)),
                new Reservation(4, "cerf", "boniface", "+33 7 57 91 18 77", new DateTime(2021, 08, 25), 9, new Menu(5, DateTime.Today, true, null), new Formule(4, null)),
            };

            //Act
            var reponse = await _client.GetFromJsonAsync<ReponsePeriodique<Reservation>>("api/reservations?debut=2021-08-30&fin=2021-09-03&page=1&taillepage=4");

            //Assert
            Assert.Equal(reservations, reponse.Donnees);
        }

        [Fact]
        public async Task GetAllReservationsAsync_Should_Be_BadRequest()
        {
            //Act
            var reponse = await _client.GetAsync("api/reservations?debut=2021-09-03&fin=2021-08-30");

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, reponse.StatusCode);
        }

        [Fact]
        public async Task GetReservationAsync_Should_Be_OK()
        {
            //Arrange
            Reservation reservation = new(3, "lussier", "sigolène", "+33 6 52 35 15 82", new DateTime(2021, 08, 27), 4, new Menu(6, DateTime.Today, true, null), new Formule(6, null));

            //Act
            var reponse = await _client.GetFromJsonAsync<Reservation>("api/reservations/3");
            var statusCode = await _client.GetAsync("api/reservations/3");

            //Assert
            Assert.Equal(reservation, reponse);
            Assert.Equal(HttpStatusCode.OK, statusCode.StatusCode);
        }

        [Fact]
        public async Task GetReservationAsync_Should_Be_NotFound()
        {
            //Act
            var statusCode = await _client.GetAsync("api/reservations/1000");

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, statusCode.StatusCode);
        }

        [Fact]
        public async Task InsertReservartionAsync_Should_Be_Created()
        {
            //Arrange
            Reservation reservation = new(null, "lussier", "sigolène", "+33 6 52 35 15 82", new DateTime(2021,08,23), 4, new Menu(6, DateTime.Today, true, null), new Formule(6, null));

            //Act
            var reponse = await _client.PostAsJsonAsync<Reservation>("api/reservations", reservation);

            //Assert
            Assert.Equal(HttpStatusCode.Created, reponse.StatusCode);
        }

        [Fact]
        public async Task InsertReservationsAsync_Should_Be_BadRequest()
        {
            //Act
            var badRequestNom = await _client.PostAsJsonAsync<Reservation>("api/reservations", new Reservation(null, "", "sigolène", "+33 6 52 35 15 82", new DateTime(2021, 08, 23), 4, new Menu(6, DateTime.Today, true, null), new Formule(6, null)));
            var badRequestPrenom = await _client.PostAsJsonAsync<Reservation>("api/reservations", new Reservation(null, "lussier", "", "+33 6 52 35 15 82", new DateTime(2021, 08, 23), 4, new Menu(6, DateTime.Today, true, null), new Formule(6, null)));
            var badRequestNumTel = await _client.PostAsJsonAsync<Reservation>("api/reservations", new Reservation(null, "lussier", "sigolène", "", new DateTime(2021, 08, 23), 4, new Menu(6, DateTime.Today, true, null), new Formule(6, null)));
            var badRequestNbPersonne = await _client.PostAsJsonAsync<Reservation>("api/reservations", new Reservation(null, "lussier", "sigolène", "+33 6 52 35 15 82", new DateTime(2021, 08, 23), 100, new Menu(6, DateTime.Today, true, null), new Formule(6, null)));
            var badRequestIdFormule = await _client.PostAsJsonAsync<Reservation>("api/reservations", new Reservation(null, "lussier", "sigolène", "+33 6 52 35 15 82", new DateTime(2021, 08, 23), 4, new Menu(6, DateTime.Today, true, null), new Formule(10, null)));
            var badRequestMenu = await _client.PostAsJsonAsync<Reservation>("api/reservations", new Reservation(null, "lussier", "sigolène", "+33 6 52 35 15 82", new DateTime(2021, 08, 23), 4, new Menu(100, DateTime.Today, true, null), new Formule(6, null)));
            var badRequestDteButoire = await _client.PostAsJsonAsync<Reservation>("api/reservations", new Reservation(null, "lussier", "sigolène", "+33 6 52 35 15 82", new DateTime(2021, 08, 31), 4, new Menu(6, DateTime.Today, true, null), new Formule(6, null)));

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, badRequestNom.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, badRequestPrenom.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, badRequestNumTel.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, badRequestNbPersonne.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, badRequestIdFormule.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, badRequestMenu.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, badRequestDteButoire.StatusCode);
        }

        [Fact]
        public async Task UpdateReservationAsync_Should_Be_OK()
        {
            //Arrange
            Reservation reservation = new(5, "cuvier", "elie", "+33 6 52 35 15 82", new DateTime(2021, 08, 23), 1, new Menu(1, DateTime.Today, true, null), new Formule(1, null));

            //Act
            var reponse = await _client.PutAsJsonAsync<Reservation>("api/reservations/5", reservation);

            //Assert
            Assert.Equal(HttpStatusCode.OK, reponse.StatusCode);
        }

        [Fact]
        public async Task UpdateReservationAsync_Should_Be_BadRequest()
        {
            //Act
            var badRequestNull = await _client.PutAsJsonAsync<Reservation>("api/reservations/5", new Reservation());
            var badRequestId = await _client.PutAsJsonAsync<Reservation>("api/reservations/5", new Reservation(10, "cuvier", "elie", "+33 6 52 35 15 82", new DateTime(2021, 08, 23), 1, new Menu(1, DateTime.Today, true, null), new Formule(1, null)));

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, badRequestNull.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, badRequestId.StatusCode);
        }

        [Fact]
        public async Task UpdateReservationAsync_Should_Be_NotFound()
        {
            //Arrange
            Reservation reservation = new(1000, "cuvier", "elie", "+33 6 52 35 15 82", new DateTime(2021, 08, 23), 1, new Menu(1, DateTime.Today, true, null), new Formule(1, null));

            //Act
            var reponse = await _client.PutAsJsonAsync<Reservation>("api/reservations/1000", reservation);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, reponse.StatusCode);
        }

        [Fact]
        public async Task DeleteReservationAsync_Should_Be_Deleted()
        {
            //Act
            var reponse = await _client.DeleteAsync("api/reservations/7");

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, reponse.StatusCode);
        }

        [Fact]
        public async Task DeleteReservationAsync_Should_Be_NotFound()
        {
            //Act
            var reponse = await _client.DeleteAsync("api/reservations/1000");

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, reponse.StatusCode);
        }
    }
}
