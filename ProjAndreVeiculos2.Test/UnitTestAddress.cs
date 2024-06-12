using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculos2.Customer.Api.Data;
using ProjAndreVeiculos2.Customer.Api.Controllers;

namespace ProjAndreVeiculos2.Test
{
    public class UnitTestAddress
    {
        private DbContextOptions<ProjAndreVeiculos2CustomerApiContext> options;
        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<ProjAndreVeiculos2CustomerApiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new ProjAndreVeiculos2CustomerApiContext(options))
            {
                context.Address.Add(new Address { Id = 1, Description = "Street 1", CEP = "123456789" });
                context.Address.Add(new Address { Id = 2, Description = "Street 2", CEP = "987654321" });
                context.Address.Add(new Address { Id = 3, Description = "Street 3", CEP = "159647841" });
                context.SaveChanges();
            }
        }


        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new ProjAndreVeiculos2CustomerApiContext(options))
            {
                AddressesController clientController = new AddressesController(context);
                IEnumerable<Address> clients = clientController.GetAddress().Result.Value;

                Assert.Equal(3, clients.Count());
            }
        }

        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new ProjAndreVeiculos2CustomerApiContext(options))
            {
                int clientId = 2;
                AddressesController clientController = new AddressesController(context);
                Address client = clientController.GetAddress(clientId).Result.Value;
                Assert.Equal(2, client.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            Address address = new Address()
            {
                Id = 4,
                Description = "Avenida Alberto Benassi",
                CEP = "14804300"
            };

            // Use a clean instance of the context to run the test
            using (var context = new ProjAndreVeiculos2CustomerApiContext(options))
            {
                AddressesController clientController = new AddressesController(context);
                Address ad = clientController.PostAddress(address).Result.Value;
                Assert.Equal("Avenida Alberto Benassi", ad.Description);
            }
        }
    }
}