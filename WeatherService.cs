using System.Text.Json;

namespace WeatherAPI
{
    public class WeatherService
    {

        private readonly HttpClient client;
        private readonly string _apiKey;
        private readonly DateTime Today = DateTime.UtcNow.Date;



        public WeatherService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            _apiKey = configuration["ApiKeys:WeatherApi"];
        }

        public async Task<WeatherResponse> GetWeatherResponseAsync(string city)
        {
            string formattedDate = Today.ToString("yyyy-MM-dd");
            string url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}/{formattedDate}?key={_apiKey}";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();
                WeatherResponse weather = JsonSerializer.Deserialize<WeatherResponse>(content);
                return weather;
            }
            else
            {
                return null;
            }
        }

    }
}
