using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Application.Services.Interfaces
{
    public interface ICalculoJurosService
    {
        Task<decimal> GetJuros(decimal valorInicial, int meses);
    }
}
