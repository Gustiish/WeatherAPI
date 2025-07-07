using StackExchange.Redis;
using System.Text.Json;

namespace WeatherAPI
{
    public class WeatherService
    {

        private readonly HttpClient client;
        private readonly string _apiKey;
        private readonly DateTime Today = DateTime.UtcNow.Date;
        private readonly IDatabase _redisDb;



        public WeatherService(HttpClient client, IConfiguration configuration, IDatabase db)
        {
            this.client = client;
            _apiKey = configuration["ApiKeys:WeatherApi"];
            _redisDb = db;
        }

        public async Task<WeatherResponse> GetWeatherResponseAsync(string city)
        {
            string formattedDate = Today.ToString("yyyy-MM-dd");
            string url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}/{formattedDate}?key={_apiKey}&unitGroup=metric";

            string cacheKey = $"weather:{city.Trim().ToLowerInvariant()}";


            string cached = await _redisDb.StringGetAsync(cacheKey);
            if (!string.IsNullOrEmpty(cached))
            {
                return JsonSerializer.Deserialize<WeatherResponse>(cached);
            }


            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();
                WeatherResponse weather = JsonSerializer.Deserialize<WeatherResponse>(content);

                await _redisDb.StringSetAsync(cacheKey, JsonSerializer.Serialize(weather), TimeSpan.FromHours(3));

                return weather;
            }
            else
            {
                return null;
            }
        }

    }
}
