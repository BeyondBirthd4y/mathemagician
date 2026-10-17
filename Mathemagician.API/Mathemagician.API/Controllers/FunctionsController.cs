using Mathemagician.Domain.Interfaces.Infra;
using Mathemagician.Services.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Mathemagician.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FunctionsController
    {
        private readonly ILogger<FunctionsController> _logger;
        public FunctionsController(ILogger<FunctionsController> logger,
            IBacenRepository bacenRepository)
        {
            _logger = logger;
        }

        [HttpGet("fatorial")]
        public long Fatorial(long number)
        {
            return MultiplicationFunctions.Fatorial(number);
        }
    }
}
