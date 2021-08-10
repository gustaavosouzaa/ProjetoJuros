using CalculaJuros.Application.Services.Interfaces;
using CalculaJuros.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculaJuros.Application.Services
{
    public class CalculoJurosService : ICalculoJurosService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl;

        public CalculoJurosService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _baseUrl = configuration.GetSection("Services:CalculateInterest").Value;
        }

        public async Task<decimal> GetJuros(decimal valorInicial, int meses)
        {
            var url = $"{_baseUrl}/taxaJuros";

            var httpClient = _httpClientFactory.CreateClient("TaxaJuros");
            var taxa = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();

            TaxaJurosViewModel view = JsonSerializer.Deserialize<TaxaJurosViewModel>(taxa.Result);
            // view.TaxaJuros = taxa.Result[0];

            return CalculoJurosComposto(valorInicial, view.TaxaJuros, meses);
        }

        private decimal CalculoJurosComposto(decimal valorInicial, double taxa, int meses)
        {
            decimal valorFinal = valorInicial * Convert.ToDecimal(Math.Pow((1 + taxa), meses));

            return TruncateDecimal(valorFinal, 2);
        }

        public decimal TruncateDecimal(decimal valorFinal, int precisao)
        {
            decimal step = (decimal)Math.Pow(10, precisao);
            decimal tmp = Math.Truncate(step * valorFinal);
            return tmp / step;
        }
    }
}
