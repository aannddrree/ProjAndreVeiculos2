using MongoDB.Driver;
using ProjAndreVeiculos2.Bank.Api.Utils;

namespace ProjAndreVeiculos2.Bank.Api.Services
{
    public class BankService
    {
        private readonly IMongoCollection<Models.Bank> _bank;

        public BankService(IProjMongoDBAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _bank = database.GetCollection<Models.Bank>(settings.BankCollectionName);
        }

        public List<Models.Bank> Get() => _bank.Find(address => true).ToList();
        public Models.Bank Get(string id) => _bank.Find<Models.Bank>(bank => bank.Id == id).FirstOrDefault();

        public Models.Bank Create(Models.Bank bank)
        {
            _bank.InsertOne(bank);
            return bank;
        }
    }
}
