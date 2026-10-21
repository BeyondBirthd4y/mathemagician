using Mathemagician.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemagician.Services.Operations
{
    public class PercentualServices : IPercentualServices
    {
        public float CalculoAumento(float value, float percentual )
        {
            return value + (value * (percentual/100));
        }

        public float CalculoReducao(float value, float percentual)
        {
            return value - (value * (percentual / 100));
        }

        public double JurosCompostos(double capitalInicial, double taxaJuros, int tempoAnos) 
        {
            var montante = capitalInicial * Math.Pow(1 + (taxaJuros / 100), Convert.ToDouble(tempoAnos));

            return Math.Round(montante, 2);
        }
    }
}
