using Mathemagician.Domain.Interfaces.Infra;
using Mathemagician.Domain.Interfaces.Services;
using Mathemagician.Services.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Mathemagician.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FunctionsController
    {
        private readonly ILogger<FunctionsController> _logger;
        private readonly IMultiplicationFunctions _multiplicationFunctions;
        public FunctionsController(ILogger<FunctionsController> logger,
            IMultiplicationFunctions multiplicationFunctions)
        {
            _logger = logger;
            _multiplicationFunctions = multiplicationFunctions;
        }

        [HttpGet("fatorial")]
        public long Fatorial(long number)
        {
            return _multiplicationFunctions.Fatorial(number);
        }
    }
}
