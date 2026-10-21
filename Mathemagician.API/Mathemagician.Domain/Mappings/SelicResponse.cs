using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Mathemagician.Domain.Mappings
{
    public class SelicResponse
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("valor")]
        public string Valor { get; set; }
    }
}
