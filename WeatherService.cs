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
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return content;
            }
            else
            {
                return null;
            }
        }







    }
}
