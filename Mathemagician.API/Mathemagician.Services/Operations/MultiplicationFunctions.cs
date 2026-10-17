using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mathemagician.Services.Operations
{
    public class MultiplicationFunctions
    {
        public static long Fatorial(long number)
        {
            long result = 1;

            for (var i = number; i > 0; i--)
                result *= i;

            return result;
        }
    }
}
