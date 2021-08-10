using System;
using System.Collections.Generic;
using System.Text;

namespace RetornarJuros.Application.DTOs
{
    public class TaxaJurosDTO
    {
        public TaxaJurosDTO(double taxaJuros)
        {
            TaxaJuros = taxaJuros;
        }

        public double TaxaJuros { get; set; }
    }
}
