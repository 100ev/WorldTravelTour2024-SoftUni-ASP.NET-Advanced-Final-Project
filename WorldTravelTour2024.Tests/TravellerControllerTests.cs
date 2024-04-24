using Moq;
using WorldTravelTour2024.Controllers;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.Agent;
using WorldTravelTour2024.Core.Models.Traveller;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Tests
{
    public class TravellerControllerTests
    {
        [Test]
        public void TravellerController_BecomeTraveller_ShouldWorkCorrectly()
        {
            var traveller = new Traveller()
            {
                UserId = "e01a6836-0506-4652-9622-81f2815535f4",
                FirstName = "Danny",
                LastName = "Glover",
                PhoneNumber = "1234321",
                Age = 78
            };

            var mockTravellerService = new Mock<ITravellerService>();
            mockTravellerService.Setup(t => t.RegisterAsync("c0e7e2be-e737-44f2-bf0b-83bb856a77e5", "Danny", "Glover", "1234321", 75))
                .Returns(Task.FromResult(traveller));
            var registeredTraveller = new BecomeTravellerFormModel()
            {
                Id = 1,
                FirstName = traveller.FirstName,
                LastName = traveller.LastName,
                PhoneNumber = traveller.PhoneNumber,
                Age = traveller.Age
            };
            var controller = new TravellerController(mockTravellerService.Object, null);
            var travellerToRegister = (controller.BecomeTraveller(registeredTraveller));
            Assert.IsNotNull(travellerToRegister);
        }

        [TestCase(1)]
        public void TravellerController_DeleteTraveller_ShouldWorkCorrectly(int travellerId)
        {
            var traveller = new Traveller
            {
                Id = 1
            };

            var mockTravellerService = new Mock<ITravellerService>();
            mockTravellerService.Setup(t => t.DeleteByIdAsync(travellerId))
                .Returns(Task.FromResult(traveller));

            var controller = new TravellerController(mockTravellerService.Object, null);
            var travellerToRemove = controller.DeleteTraveller(travellerId);
            Assert.IsNotNull(travellerToRemove);
        }

        [TestCase(1)]
        public void TravellerController_UpdateInformation_ShouldWorkCorrectly(int travellerId)
        {
            string newLastName = "MelGibson";
            string newPhonenUmber = "84304701";
            var traveller = new BecomeTravellerFormModel()
            {
                Id = 1,
            };

            var mockTravellerService = new Mock<ITravellerService>();
            mockTravellerService.Setup(t => t.UpdateInformationAsync(travellerId, newLastName, newPhonenUmber))
                .Returns(Task.FromResult(traveller));

            var controller = new TravellerController(mockTravellerService.Object, null);
            var travellerToUpdate = controller.UpdateInformation(traveller, travellerId, newLastName, newPhonenUmber);
            Assert.IsNotNull(travellerToUpdate);
        }


        [TestCase(2, 1)]
        public void TravellerController_DeclineReservation_ShouldWorkCorrectly(int hostId, int travellerId)
        {

            var mocTravellerService = new Mock<ITravellerService>();
            mocTravellerService.Setup(t => t.DeclineResrevation(travellerId));

            var controller = new TravellerController(mocTravellerService.Object, null);
            var declinedReservation = controller.DeclineReservation(hostId, travellerId);
            Assert.IsNotNull(declinedReservation);
        }

        [Test]
        public void TravellerController_MakeReservation_ShouldWorkCorrectly()
        {
            var reservation = new ReservationCreatedFormModel()
            {
                TravellerId = 1,
                HostId = 3,
                NumberOfNigths = 7,
                NumberOfTravellers = 4,
            };

            var mocTravellerService = new Mock<ITravellerService>();
            mocTravellerService.Setup(t => t.MakeReservation(1, 3, 7, 4));

            var controller = new TravellerController(mocTravellerService.Object, null);
            var createdReservation = controller.MakeReservation(reservation, 1, 3, 7, 4);
            Assert.IsNotNull(createdReservation);
        }
    }
}
