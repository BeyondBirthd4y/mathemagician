using Mathemagician.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemagician.Domain.Interfaces.Infra
{
    public interface IBacenRepository
    {
        Task<TaxaSelic> ObterSelicAtualAsync();
    }
}
