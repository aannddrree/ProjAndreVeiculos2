using System.Runtime.ConstrainedExecution;
using Models;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ProjAndreVeiculos2.Customer.Api.Services
{
    public class BankService
    {
        static readonly HttpClient bankClient = new HttpClient();

        public BankService() { 
        
        }

        public async Task<Models.Bank> PostBank (Models.Bank bank)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await BankService.bankClient.PostAsync("https://localhost:7128/api/Bank", content);
                response.EnsureSuccessStatusCode();
                string bankReturn = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<Models.Bank>(bankReturn);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

    }
}
