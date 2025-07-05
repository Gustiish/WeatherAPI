using System.Text.Json.Serialization;

namespace WeatherAPI
{
    public class WeatherDTO
    {
        [JsonPropertyName("tempmax")]
        public double TempMax { get; set; }
        [JsonPropertyName("tempmin")]
        public double TempMin { get; set; }
        [JsonPropertyName("conditions")]
        public string Conditions { get; set; }

    }
}

