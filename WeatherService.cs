namespace WeatherAPI
{
    public class WeatherService
    {

        private readonly HttpClient client;
        private readonly string _apiKey = "EJ3VQ2UYTXCR6LNFGB7SJ5QCQ";

        public WeatherService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<string> GetWeatherResponseAsync(string city)
        {
            string url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?unitGroup=metric&key={_apiKey}&contentType=json";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }
        }







    }
}
