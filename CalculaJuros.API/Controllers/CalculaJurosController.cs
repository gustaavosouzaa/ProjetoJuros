using CalculaJuros.Application.Services.Interfaces;
using CalculaJuros.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculaJuros.API.Controllers
{
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculoJurosService _calculoJurosService;

        public CalculaJurosController(ICalculoJurosService calculoJurosService)
        {
            _calculoJurosService = calculoJurosService;
        }

        [HttpGet("calculajuros")]
        public async Task<ActionResult> Get(decimal valorInicial, int meses)
        {
            if (valorInicial == 0 || meses == 0)
                return NotFound();

            var resposta = await _calculoJurosService.GetJuros(valorInicial, meses);

            return Ok(resposta);

        }

        [HttpGet("showmethecode")]
        public ActionResult GetCode()
        {
            return Ok(new VisualizarCodigoViewModel());
        }
    }
}
