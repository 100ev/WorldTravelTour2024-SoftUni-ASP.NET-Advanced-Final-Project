using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldTravelTour2024.Infrastructure.Constants;
using WorldTravelTour2024.Infrastructure.Data.Models;

namespace WorldTravelTour2024.Infrastructure.Data.SeedDb
{
    public class SeedDatabase
    {
        public IdentityUser TravellerUser { get; set; } = new IdentityUser();
        public IdentityUser HostUser { get; set; } = new IdentityUser();
        public IdentityUser TransportationProviderUser { get; set; } = new IdentityUser();
        public IdentityUser AgentUser { get; set; } = new IdentityUser();
        public Traveller Traveller { get; set; } = null!;
        public Host Host { get; set; } = null!;
        public TransportationProvider TransportationProvider { get; set; } = null!;
        public Agent Agent { get; set; } = null!;
        public Continent Africa { get; set; } = null!;
        public Continent NorthAmerica { get; set; } = null!;
        public Continent SouthAmerica { get; set; } = null!;
        public Continent Europe { get; set; } = null!;
        public Continent Asia { get; set; } = null!;
        public Continent Australia { get; set; } = null!;
        public Continent Antarctica { get; set; } = null!;

        public SeedDatabase()
        {
            SeedUsers();
            SeedTravellers();
            SeedHosts();
            SeedTransportationProviders();
            SeedAgents();
            SeedContinents();
        }
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var TravellerUser = new IdentityUser()
            {
                Id = "qwerty12345678",
                UserName = "our-beloved-traveller",
                NormalizedUserName = "our-beloved-traveller",
                NormalizedEmail = "traveller@mail.com"
            };

            TravellerUser.PasswordHash = hasher
                .HashPassword(TravellerUser, "traveller321");

            var HostUSer = new IdentityUser()
            {
                Id = "zxcvbn1234567",
                UserName = "our-generous-host@mail.com",
                NormalizedUserName = "our-generous-host",
                NormalizedEmail = "host@mail.com"
            };

            HostUSer.PasswordHash = hasher
                .HashPassword(HostUSer, "host123");

            var TransportationProviderUser = new IdentityUser()
            {
                Id = "asdfg1234567",
                UserName = "our-great-transporter@mail.com",
                NormalizedUserName = "our-great-transporter",
                NormalizedEmail = "transportationprovider@mail.com"
            };

            TransportationProviderUser.PasswordHash = hasher
                .HashPassword(TransportationProviderUser, "jasonstatham123");

            var AgentUser = new IdentityUser()
            {
                Id = "qaz1234567",
                UserName = "our-precious-agent@mail.com",
                NormalizedUserName = "our-precious-agent",
                NormalizedEmail = "agent@mail.com"
            };

            AgentUser.PasswordHash = hasher.HashPassword(AgentUser, "agent12321");
        }

        private void SeedTravellers()
        {
            Traveller = new Traveller()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Age = 29,
                PhoneNumber = "032756657",
                Money = 1000.00M
            };
        }

        public void SeedHosts()
        {
            Host = new Host()
            {
                Id = 1,
                FirstName = "Frodo",
                LastName = "Baggins",
                Email = "ringbearer@mail.com",
                Address = "Miami, Florida, Palm Street 1",
                PhoneNumber = "01973397",
                Rooms = 3,
                PricePerNight = 200.00M,
                Wallet = 0.00M,
            };
        }

        public void SeedTransportationProviders()
        {
            TransportationProvider = new TransportationProvider()
            {
                Id = 1,
                FirstName = "Jason",
                LastName = "Statham",
                PhoneNumber = "044258852",
                CountryNameToTransportGuest = "Egypt",
                Profit = 0.00M
            };
        }

        public void SeedAgents()
        {
            Agent = new Agent()
            {
                Id = 1,
                FirstName = "Agent",
                LastName = "47",
                PhoneNumber = "004712345",
                Email = "agent47@mail.com",
                Profit = 0.00M,
                HostId = Host.Id,                
                TransportationProviderId = TransportationProvider.Id,
                TravellerId = Traveller.Id
            };
        }

        public void SeedContinents()
        {

            Europe = new Continent()
            {
                Id = 1,
                Name = "Europe",
                IsVisitableDuringThisSeason = true,
            };

            Asia = new Continent()
            {
                Id = 2,
                Name = "Asia",
                IsVisitableDuringThisSeason = true,
            };

            Africa = new Continent()
            {
                Id = 3,
                Name = "Africa",
                IsVisitableDuringThisSeason = true
            };

            SouthAmerica = new Continent()
            {
                Id = 4,
                Name = "South America",
                IsVisitableDuringThisSeason = true
            };

            NorthAmerica = new Continent()
            {
                Id = 5,
                Name = "North America",
                IsVisitableDuringThisSeason = true
            };

            Australia = new Continent()
            {
                Id = 6,
                Name = "Australia",
                IsVisitableDuringThisSeason = true
            };

            Antarctica = new Continent()
            {
                Id = 7,
                IsVisitableDuringThisSeason = true,
                Name = "Antarctica",
            };
        }
    }
}
