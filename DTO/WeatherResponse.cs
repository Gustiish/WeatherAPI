using System.Text.Json.Serialization;

namespace WeatherAPI
{
    public class WeatherResponse
    {
        [JsonPropertyName("resolvedAddress")]
        public string ResolvedAddress { get; set; }
        [JsonPropertyName("days")]
        public List<WeatherDTO> Days { get; set; }
    }
}
