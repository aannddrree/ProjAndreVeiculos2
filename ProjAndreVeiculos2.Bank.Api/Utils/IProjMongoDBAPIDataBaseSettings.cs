namespace ProjAndreVeiculos2.Bank.Api.Utils
{
    public interface IProjMongoDBAPIDataBaseSettings
    {
        string BankCollectionName { set; get; }
        string ConnectionString { set; get; }
        string DatabaseName { set; get; }
    }
}
