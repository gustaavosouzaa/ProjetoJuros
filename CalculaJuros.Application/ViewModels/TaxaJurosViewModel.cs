using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Application.ViewModels
{
    public class TaxaJurosViewModel
    {
        public TaxaJurosViewModel(double taxaJuros)
        {
            TaxaJuros = taxaJuros;
        }

        public double TaxaJuros { get; set; }
    }
}
