using Mathemagician.Domain.Entities;
using Mathemagician.Domain.Interfaces.Infra;
using Mathemagician.Domain.Mappings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mathemagician.Infra.External
{
    public class BacenRepository : IBacenRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string Url = "https://bcb.gov.br";
        public BacenRepository(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<TaxaSelic> ObterSelicAtualAsync()
        {
            DateTime hoje = DateTime.Today;
            DateTime inicioDoMes = new DateTime(hoje.Year, hoje.Month, 1);

            string dataInicial = inicioDoMes.ToString("dd/MM/yyyy");
            string dataFinal = hoje.ToString("dd/MM/yyyy");

            // 2. Monta a URL oficial usando parâmetros de Query String
            var url = $"https://api.bcb.gov.br/dados/serie/bcdata.sgs.432/dados?formato=json&dataInicial={dataInicial}&dataFinal={dataFinal}";

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) MathemagicianAPI/1.0");

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();


            var dados = JsonSerializer.Deserialize<List<SelicResponse>>(jsonResponse);

            if (dados == null || dados.Count == 0)
                throw new Exception("Não foi possível obter a taxa Selic");

            var registroAtual = dados[0];

            DateTime data = DateTime.ParseExact(registroAtual.Data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            decimal valor = decimal.Parse(registroAtual.Valor, CultureInfo.InvariantCulture);
            return new TaxaSelic(data, valor);
        }
    }
}
