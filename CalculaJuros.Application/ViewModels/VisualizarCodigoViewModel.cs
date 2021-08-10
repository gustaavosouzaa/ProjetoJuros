using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Application.ViewModels
{
    public class VisualizarCodigoViewModel
    {
        public VisualizarCodigoViewModel()
        {
            Repositorio = "github";
            Url = "https://github.com/gustaavosouzaa/ProjetoJuros";
        }

        public string Repositorio { get; set; }
        public string Url { get; set; }
    }
}
