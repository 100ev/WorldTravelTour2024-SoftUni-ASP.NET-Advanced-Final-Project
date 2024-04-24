using Moq;
using WorldTravelTour2024.Controllers;
using WorldTravelTour2024.Core.Contracts.Host;
using WorldTravelTour2024.Core.Models.Host;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Tests
{
    public class HostControllerTests
    {
        [Test]
        public void HostController_BecomeHost_ShouldWorkCorrectly()
        {
            var host = new Host()
            {
                UserId = "c0e7e2be-e737-44f2-bf0b-83bb856a77e5",
                FirstName = "Deil",
                LastName = "Denton",
                PhoneNumber = "111234567",
                Rooms = 2
            };

            var mockHostService = new Mock<IHostService>();
            mockHostService.Setup(h => h.RegisterHostAsync("c0e7e2be-e737-44f2-bf0b-83bb856a77e5", "Deil","Denton","11234567",2))
                .Returns(Task.FromResult(host));
            var registerdHost = new BecomeHostFormModel()
            {
                Id = 1,
                FirstName = host.FirstName,
                LastName = host.LastName,
                PhoneNumber = host.PhoneNumber,
                Rooms = host.Rooms
            };
            var controller = new HostController(mockHostService.Object);
            var result = (controller.BecomeHost(registerdHost));
            Assert.IsNotNull(result);
        }

        [TestCase(1)]
        public void HostController_DeleteHost_ShouldWorkCorrectly(int hostId)
        {
            var host = new Host
            {
                Id = 1
            };

            var mockHostService = new Mock<IHostService>();
            mockHostService.Setup(h => h.RemoveAsync(hostId))
                .Returns(Task.FromResult(host));

            var controller = new HostController(mockHostService.Object);
            var hostToRemove = controller.DeleteHost(hostId);
            Assert.IsNotNull(hostToRemove);
        }

        [TestCase(1)]
        public void HostController_UpdateAddress_ShouldWorkCorrectly(int hostId)
        {
            string newAddress = "middle aerth, hobbittown";
            var host = new BecomeHostFormModel()
            {
                Id = 1,
            };

            var mockHostService = new Mock<IHostService>();
            mockHostService.Setup(h => h.UpdateAddressAsync(hostId, newAddress))
                .Returns(Task.FromResult(host));

            var controller = new HostController(mockHostService.Object);
            var hostWithAddressToUpdate = controller.UpdateAddress(host, hostId, newAddress);
            Assert.IsNotNull(hostWithAddressToUpdate);
        }
        [TestCase(1)]
        public void HostController_UpdatePersonalInformation_ShouldWorkCorrectly(int hostId)
        {
            string newPhoneNumber = "080880808";
            string newEmail = "newmail@mail.com";
            int newNumRooms = 1;

            var host = new BecomeHostFormModel()
            {
                Id = 1,
            };

            var mockHostService = new Mock<IHostService>();
            mockHostService.Setup(h => h.UpdatePersonalInformationAsync(hostId, newPhoneNumber, newEmail, newNumRooms))
                .Returns(Task.FromResult(host));

            var controller = new HostController(mockHostService.Object);
            var hostWithPersonalInformationToUpdate = controller.UpdateInformation(host, hostId, newPhoneNumber, newEmail, newNumRooms);
            Assert.IsNotNull(hostWithPersonalInformationToUpdate);
        }

        [TestCase(2, 1)]
        public void HostController_CanWelcomeTraveller_ShouldWorkCorrectly(int hostId, int travellerId)
        {
            

            var mockHostService = new Mock<IHostService>();
            mockHostService.Setup(h => h.CanWellcomeTravellerAsync(hostId, travellerId));

            var controller = new HostController(mockHostService.Object);
            var hostCanWelcomeTraveller = controller.CanWelcomeGuest(hostId, travellerId);
            Assert.IsNotNull(hostCanWelcomeTraveller);
        }
    }
}
