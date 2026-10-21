using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemagician.Domain.Interfaces.Services
{
    public interface IPercentualServices
    {
        float CalculoAumento(float value, float percentual);

        float CalculoReducao(float value, float percentual);

        double JurosCompostos(double capitalInicial, double taxaJuros, int tempoAnos);
    }
}
