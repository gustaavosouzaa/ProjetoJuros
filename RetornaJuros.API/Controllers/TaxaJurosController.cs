using Microsoft.AspNetCore.Mvc;
using RetornarJuros.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RetornaJuros.API.Controllers
{
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {

        public TaxaJurosController()
        {
        }

        [HttpGet("taxaJuros")]
        public ActionResult<TaxaJurosDTO> Get()
        {
            TaxaJurosDTO taxa = new TaxaJurosDTO(0.01);

            return Ok(JsonSerializer.Serialize(taxa));
        }
    }
}
