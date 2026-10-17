using Microsoft.AspNetCore.Mvc;
using Mathemagician.Services.Operations;
using Mathemagician.Domain.Interfaces.Infra;

namespace Mathemagician.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PercentualOperationsController : ControllerBase
    {
        private readonly ILogger<PercentualOperationsController> _logger;
        private readonly IBacenRepository _bacenRepository;

        public PercentualOperationsController(ILogger<PercentualOperationsController> logger,
            IBacenRepository bacenRepository)
        {
            _logger = logger;
            _bacenRepository = bacenRepository;
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
        public async Task<double> CalculoJurosCompostos(double capitalInicial, double taxaJuros, int tempo, string tipoTaxa = "")
        {
            if(string.IsNullOrEmpty(tipoTaxa))
                return PercentualServices.JurosCompostos(capitalInicial, taxaJuros, tempo);
            if(tipoTaxa.ToUpper() == "SELIC")
            {
                var taxaSelic = await _bacenRepository.ObterSelicAtualAsync();
                return PercentualServices.JurosCompostos(capitalInicial, Convert.ToDouble(taxaSelic.Valor), tempo);
            }

            return 0;
        }
    }
}
