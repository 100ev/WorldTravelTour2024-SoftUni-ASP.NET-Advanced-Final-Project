using Moq;
using WorldTravelTour2024.Controllers;
using WorldTravelTour2024.Core.Contracts.Agent;
using WorldTravelTour2024.Core.Models.Host;
using WorldTravelTour2024.Core.Models.Reservations;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using WorldTravelTour2024.Core.Models.Traveller;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Tests
{
    public class AgentControllerTests
    {
        [Test]
        public void AgentController_BecomeAgent_ShouldWorkCorrectly()
        {
            Agent agent = new Agent()
            {
                UserId = "6bff493a - ca91 - 4c95 - a579 - 5bd3a6c6f1bd",
                FirstName = "Eddie",
                LastName = "Murphy",
                PhoneNumber = "012345678",
                Email = "emurphy@mail.com"
            };
            var mockAgentService = new Mock<IAgentService>();
            mockAgentService
                .Setup(a => a.RegisterAgentAsync("6bff493a-ca91-4c95-a579-5bd3a6c6f1bd", "Eddie", "Murphy", "012345678", "emurphy@mail.com"))
                .Returns(Task.FromResult(agent));

            var controller = new AgentController(mockAgentService.Object);
            var registerAgent = controller.BecomeAgent();
            Assert.IsNotNull(registerAgent);
        }

        [Test]
        public void AgentController_BecomeAgent_ShouldThrowModelError_IfAgentAlreadyExist()
        {
            Agent agent = new Agent()
            {
                UserId = "6bff493a - ca91 - 4c95 - a579 - 5bd3a6c6f1bd",
                FirstName = "Eddie",
                LastName = "Murphy",
                PhoneNumber = "012345678",
                Email = "emurphy@mail.com"
            };
            var mockAgentService = new Mock<IAgentService>();
            mockAgentService
                .Setup(a => a.RegisterAgentAsync("6bff493a-ca91-4c95-a579-5bd3a6c6f1bd", "Eddie", "Murphy", "012345678", "emurphy@mail.com"))
                .Returns(Task.FromResult(agent));

            var mockAgentServiceTwice = new Mock<IAgentService>();
            mockAgentService
                .Setup(a => a.RegisterAgentAsync("6bff493a-ca91-4c95-a579-5bd3a6c6f1bd", "Eddie", "Murphy", "012345678", "emurphy@mail.com"))
                .Returns(Task.FromResult(agent));

            var controller = new AgentController(mockAgentServiceTwice.Object);
            var registerAgent = controller.BecomeAgent();
            Assert.IsNotNull(registerAgent);

        }
        [TestCase(1)]
        public void AgentController_FindTraveller_ShouldWorkCorrectly(int travellerId)
        {
            BecomeTravellerFormModel traveller = new BecomeTravellerFormModel()
            {
                Id = travellerId
            };
            var mockAgentService = new Mock<IAgentService>();
            mockAgentService
                .Setup(a => a.TravellerExistByIdAsync(1))
                .Returns(Task.FromResult(traveller));

            var controller = new AgentController(mockAgentService.Object);
            var findTraveller = controller.FindTraveller(traveller, travellerId);
            Assert.IsNotNull(findTraveller);
        }
        [TestCase(1)]
        public void AgentController_FindHost_ShouldWorkCorrectly(int hostId)
        {
            BecomeHostFormModel host = new BecomeHostFormModel()
            {
                Id = hostId
            };
            var mockAgentService = new Mock<IAgentService>();
            mockAgentService
                .Setup(a => a.HostExistByIdAsync(1))
                .Returns(Task.FromResult(host));

            var controller = new AgentController(mockAgentService.Object);
            var findHost = controller.FindHost(host, hostId);
            Assert.IsNotNull(findHost);
        }
        [TestCase(1)]
        public void AgentController_FindTranasportationProvider_ShouldWorkCorrectly(int tranasportationProviderId)
        {
            BecomeTransportationProviderFormModel transportationProvider = new BecomeTransportationProviderFormModel()
            {
                Id = tranasportationProviderId
            };
            var mockAgentService = new Mock<IAgentService>();
            mockAgentService
                .Setup(a => a.TransportationProviderExistByIdAsync(1))
                .Returns(Task.FromResult(transportationProvider));

            var controller = new AgentController(mockAgentService.Object);
            var findTrnsportationProvider = controller.FindTransportationProvider(transportationProvider, tranasportationProviderId);
            Assert.IsNotNull(findTrnsportationProvider);
        }

        [TestCase(1)]
        public void AgentController_UpdateTravellerInformation_ShouldWorkCorrectly(int travellerId)
        {
            string newName = "Novo Ime";
            string newPhoneNumber = "87654321";
            BecomeTravellerFormModel travellerToUpdate = new BecomeTravellerFormModel()
            {
                Id = 1,
                FirstName = "Staro ime",
                LastName = "Stara familia",
                PhoneNumber = "12345678"
            };

            var mockAgentService = new Mock<IAgentService>();
            mockAgentService.Setup(a => a.UpdateTravellerAsync(travellerId, newName, newPhoneNumber))
                .Returns(Task.FromResult(travellerToUpdate));

            var controller = new AgentController(mockAgentService.Object);
            var updatedTraveller = controller.UpdateTravellerInformation(travellerToUpdate, travellerId, newName, newPhoneNumber);
            Assert.IsNotNull(updatedTraveller);
        }
        [TestCase(1)]
        public void AgentController_UpdateHostInformation_ShouldWorkCorrectly(int hostId)
        {
            string newName = "Novo ImeH";
            string newPhoneNumber = "5555555";
            int newRooms = 2;
            BecomeHostFormModel hostToUpdate = new BecomeHostFormModel()
            {
                Id = 1,
                FirstName = "Staro imeH",
                LastName = "Stara familiaH",
                PhoneNumber = "65658565",
                Rooms = 1
            };

            var mockAgentService = new Mock<IAgentService>();
            mockAgentService.Setup(a => a.UpdateHostAsync(hostId, newName, newPhoneNumber, newRooms))
                .Returns(Task.FromResult(hostToUpdate));

            var controller = new AgentController(mockAgentService.Object);
            var updatedHost = controller.UpdateHostInformation(hostToUpdate, hostId, newName, newPhoneNumber, newRooms);
            Assert.IsNotNull(updatedHost);
        }
        [TestCase(1)]
        public void AgentController_UpdateTransportationProviderInformation_ShouldWorkCorrectly(int transportationProviderId)
        {
            string newPhoneNumber = "00000000";
            int newRooms = 2;
            BecomeTransportationProviderFormModel transportationProviderToUpdate = new BecomeTransportationProviderFormModel()
            {
                Id = 1,
                FirstName = "Staro imeTp",
                LastName = "Stara familiaTp",
                PhoneNumber = "65658565",
            };

            var mockAgentService = new Mock<IAgentService>();
            mockAgentService.Setup(a => a.UpdateTransportationProviderAsync(transportationProviderId, newPhoneNumber))
                .Returns(Task.FromResult(transportationProviderToUpdate));

            var controller = new AgentController(mockAgentService.Object);
            var updatedTransportationProvider = controller.UpdateTransportationproviderInformation(transportationProviderToUpdate, transportationProviderId, newPhoneNumber);
            Assert.IsNotNull(updatedTransportationProvider);
        }

        [TestCase(1)]
        public void AgentController_RemoveHost_ShouldWorkCorrectly(int hostId)
        {
            var host = new Host 
            { 
                Id = 1 
            };

            var mockAgentService = new Mock<IAgentService>();   
            mockAgentService.Setup(a => a.RemoveHostAsync(hostId))
                .Returns(Task.FromResult(host));

            var controller = new AgentController(mockAgentService.Object);
            var hostToRemove = controller.RemoveHost(hostId);
            Assert.IsNotNull(hostToRemove);
        }
        [TestCase(1)]
        public void AgentController_RemoveTraveller_ShouldWorkCorrectly(int travellerId)
        {
            var traveller = new Traveller
            {
                Id = 1
            };

            var mockAgentService = new Mock<IAgentService>();
            mockAgentService.Setup(a => a.RemoveTravellerAsync(travellerId))
                .Returns(Task.FromResult(traveller));

            var controller = new AgentController(mockAgentService.Object);
            var travellerToRemove = controller.RemoveTraveller(travellerId);
            Assert.IsNotNull(travellerToRemove);
        }
        [TestCase(1)]
        public void AgentController_RemoveTransportationProvider_ShouldWorkCorrectly(int transportationProviderId)
        {
            var transportationProvider = new TransportationProvider
            {
                Id = 1
            };

            var mockAgentService = new Mock<IAgentService>();
            mockAgentService.Setup(a => a.RemoveTransportationProviderAsync(transportationProviderId))
                .Returns(Task.FromResult(transportationProvider));

            var controller = new AgentController(mockAgentService.Object);
            var transportationProviderToRemove = controller.RemoveTransportationProvider(transportationProviderId);
            Assert.IsNotNull(transportationProviderToRemove);
        }

        [Test]
        public void AgentController_TravellerLEftEarly_ShouldWorkCorrectly()
        {
            var travellerLeftEarly = new TravellerLeftEarlyFormModel()
            {
                HostId = 1,
                TravellersLeft = 3,
                HostProfit = 200
            };
            var mockAgentService = new Mock<IAgentService>();
            mockAgentService.Setup(a => a.TravellerDecidedToLeaveEarlyAsync(1, 3))
                .Returns(Task.FromResult(travellerLeftEarly));

            var controller = new AgentController(mockAgentService.Object);
            var result = controller.TravellerLeftEarly(1, 3);
            Assert.IsNotNull(result);
        }

        [Test]
        public void AgentController_AskTransportFromTransportationProvider_ShouldWorkCorrectly()
        {
            int travellerId = 2;
            int transportationProviderId = 1;
            string country = "Cameroon";

            var mockAgentService = new Mock<IAgentService>();
            mockAgentService
                .Setup(a => a.AskTransportFromTransportationProviderAsync(travellerId, transportationProviderId, country));
            var controller = new AgentController(mockAgentService.Object);
            var result = controller.AskHelpFromTransportationProvider(travellerId, transportationProviderId, country);
            Assert.IsNotNull(result);
        }
    }
}
