namespace IBASEmployeeService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using IBASEmployeeService.Models;
    using Microsoft.Azure.Cosmos;
    using IBASEmployeeService.Services;
    using System.ComponentModel;
    using Microsoft.Azure.Cosmos.Linq;
    using System.Threading.Tasks;
    using Container = Microsoft.Azure.Cosmos.Container;

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly CosmosDbService _cosmosDbService;

        public EmployeeController(CosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpGet("/henvendelser")]
        public async Task<List<Henvendelse>> GetTestAsync()
        {
            return await _cosmosDbService.GetHenvendelserAsync();
        }

        //bruges til at tjekke om det kommer igennem. HUSK ændre tallet hver gang der laves ændring 
        [HttpGet("/version")]
        public IActionResult GetVersion()
        {
            return Ok("1.0.0");
        }




        [HttpPost("/add")]
        public void Post(HenvendelseDTO test)
        {
            _cosmosDbService.PostHenvendelse(test);
        }
    }
}