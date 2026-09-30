using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemagician.Services.Percentual
{
    public class PercentualServices
    {
        public static float CalculoAumento(float value, float percentual )
        {
            return value + (value * (percentual/100));
        }

        public static float CalculoReducao(float value, float percentual)
        {
            return value - (value * (percentual / 100));
        }
    }
}
