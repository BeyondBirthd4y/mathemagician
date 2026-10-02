using Microsoft.AspNetCore.Mvc;
using Mathemagician.Services.Percentual;

namespace Mathemagician.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PercentualOperationsController : ControllerBase
    {
        private readonly ILogger<PercentualOperationsController> _logger;

        public PercentualOperationsController(ILogger<PercentualOperationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("aumento")]
        public float CalculoAumento(float valor, float percentual)
        {
            return PercentualServices.CalculoAumento(valor, percentual);
        }

        [HttpGet("reducao")]
        public float CalculoReducao(float valor, float percentual)
        {
            return PercentualServices.CalculoReducao(valor, percentual);
        }

        [HttpGet("juros-compostos")]
        public double CalculoJurosCompostos(double capitalInicial, double taxaJuros, int tempo)
        {
            return PercentualServices.JurosCompostos(capitalInicial, taxaJuros, tempo);
        }
    }
}
