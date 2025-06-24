namespace WeatherAPI
{
    public static class WeatherApiEndpoints
    {
        public static void MapWeatherEndpoints(this WebApplication application)
        {
            application.MapGet("/weather/{city}", async (string city, WeatherService service) =>
            {
                var json = await service.GetWeatherResponseAsync(city);
                if (json == null)
                {
                    return Results.Problem("Could not fetch weather");
                }
                else
                {
                    return Results.Content(json.ToString(), "application/json");
                }

            });

        }



    }
}
