using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemagician.Domain.Entities
{
    public class TaxaSelic
    {
        public DateTime DataVigencia { get; set; }
        public decimal Valor {  get; set; }

        public TaxaSelic( DateTime dataVigencia, decimal valor) 
        { 
            DataVigencia = dataVigencia;
            Valor = valor;
        }
    }
}
