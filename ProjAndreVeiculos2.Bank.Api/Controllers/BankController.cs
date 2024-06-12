using Microsoft.AspNetCore.Mvc;
using Models;
using ProjAndreVeiculos2.Bank.Api.Services;

namespace ProjAndreVeiculos2.Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankService _bankService;

        public BankController(BankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public ActionResult<List<Models.Bank>> Get()
        {
            return _bankService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetBank")]
        public ActionResult<Models.Bank> Get(string id)
        {
            return _bankService.Get(id);
        }

        [HttpPost]
        public ActionResult<Models.Bank> Create(Models.Bank bank)
        {
            _bankService.Create(bank);
            return CreatedAtRoute("GetBank", new { id = bank.Id }, bank);
        }
    }
}
