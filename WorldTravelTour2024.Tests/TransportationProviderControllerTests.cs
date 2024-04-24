using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldTravelTour2024.Controllers;
using WorldTravelTour2024.Core.Contracts.TransportationProvider;
using WorldTravelTour2024.Core.Contracts.Traveller;
using WorldTravelTour2024.Core.Models.TransportationProvider;
using WorldTravelTour2024.Core.Models.Traveller;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Tests
{
    public class TransportationProviderControllerTests
    {
        [Test]
        public void TransportationProviderController_BecomeTransportationProvider_ShouldWorkCorrectly()
        {
            var transportationProvider = new TransportationProvider()
            {
                UserId = "3d0587d7-1ebf-4d64-b74a-43dcac1c1ed0",
                FirstName = "Tom",
                LastName = "Hardy",
                PhoneNumber = "044698547"
            };

            var mockTransportationProviderService = new Mock<ITransportationProviderService>();
            mockTransportationProviderService.Setup(tp => tp.RegisterTransportationProviderAsync("3d0587d7-1ebf-4d64-b74a-43dcac1c1ed0", "Tom", "Hardy", "044698547"))
                .Returns(Task.FromResult(transportationProvider));
            var registeredTransportationProvider = new BecomeTransportationProviderFormModel()
            {
                Id = 1,
                FirstName = transportationProvider.FirstName,
                LastName = transportationProvider.LastName,
                PhoneNumber = transportationProvider.PhoneNumber,
            };
            var controller = new TransportationProviderController(mockTransportationProviderService.Object, null);
            var transportationProviderToRegister = (controller.BecomeTransportationProvider(registeredTransportationProvider));
            Assert.IsNotNull(transportationProviderToRegister);
        }

        [TestCase(1)]
        public void TransportationProviderController_DeleteTransportationProvider_ShouldWorkCorrectly(int transportationProviderId)
        {
            var transportationProvider = new TransportationProvider()
            {
                Id = 1
            };

            var mockTransportationProviderService = new Mock<ITransportationProviderService>();
            mockTransportationProviderService.Setup(tp => tp.RemoveAsync(transportationProviderId))
                .Returns(Task.FromResult(transportationProvider));

            var controller = new TransportationProviderController(mockTransportationProviderService.Object, null);
            var transportationProviderToRemove = controller.RemoveTransportationProvider(transportationProvider.Id);
            Assert.IsNotNull(transportationProviderToRemove);
        }

        [TestCase(1)]
        public void TransportationProviderController_UpdateInformation_ShouldWorkCorrectly(int transportationProviderId)
        {            
            string newPhonenUmber = "777777";
            var transportationProvider = new BecomeTransportationProviderFormModel()
            {
                Id = 1,
            };

            var mockTransportationProviderService = new Mock<ITransportationProviderService>();
            mockTransportationProviderService.Setup(tp => tp.UpdatePersonalInformationAsync(transportationProviderId, newPhonenUmber))
                .Returns(Task.FromResult(transportationProvider));

            var controller = new TransportationProviderController(mockTransportationProviderService.Object, null);
            var transportationProviderToUpdate = controller.UpdateInformation(transportationProvider.Id, newPhonenUmber);
            Assert.IsNotNull(transportationProviderToUpdate);
        }
        [TestCase("USA")]
        public void TransportationProviderController_CAnTransportToDestination_ShouldWorkCorrectly(string country)
        {
            int travellerId = 3;
            int transportationProviderID = 2;
            int numTravellrs = 2;
            var mockTransportationProviderService = new Mock<ITransportationProviderService>();
            mockTransportationProviderService.Setup(tp => tp.CanTransportTravellerToCountryAsync("USA"));

            var controller = new TransportationProviderController(mockTransportationProviderService.Object, null);
            var transportationPossible = controller
                .CanTransportTravelelrToDestination(transportationProviderID, travellerId, country, numTravellrs);
            Assert.IsNotNull(transportationPossible);
        }
    }
}
