using Microsoft.AspNetCore.Mvc;
using Mathemagician.Services.Operations;
using Mathemagician.Domain.Interfaces.Infra;
using Mathemagician.Domain.Interfaces.Services;

namespace Mathemagician.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PercentualOperationsController : ControllerBase
    {
        private readonly ILogger<PercentualOperationsController> _logger;
        private readonly IBacenRepository _bacenRepository;
        private readonly IPercentualServices _percentualServices;

        public PercentualOperationsController(ILogger<PercentualOperationsController> logger,
            IBacenRepository bacenRepository,
            IPercentualServices percentualServices)
        {
            _logger = logger;
            _bacenRepository = bacenRepository;
            _percentualServices = percentualServices;
        }

        [HttpGet("aumento")]
        public float CalculoAumento(float valor, float percentual)
        {
            return _percentualServices.CalculoAumento(valor, percentual);
        }

        [HttpGet("reducao")]
        public float CalculoReducao(float valor, float percentual)
        {
            return _percentualServices.CalculoReducao(valor, percentual);
        }

        [HttpGet("juros-compostos")]
        public async Task<double> CalculoJurosCompostos(double capitalInicial, double taxaJuros, int tempo, string tipoTaxa = "")
        {
            if(string.IsNullOrEmpty(tipoTaxa))
                return _percentualServices.JurosCompostos(capitalInicial, taxaJuros, tempo);
            if(tipoTaxa.ToUpper() == "SELIC")
            {
                var taxaSelic = await _bacenRepository.ObterSelicAtualAsync();
                return _percentualServices.JurosCompostos(capitalInicial, Convert.ToDouble(taxaSelic.Valor), tempo);
            }

            return 0;
        }
    }
}
