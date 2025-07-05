namespace WeatherAPI
{
    public static class WeatherApiEndpoints
    {
        public static void MapWeatherEndpoints(this WebApplication application)
        {
            application.MapGet("/weather/{city}", async (string city, WeatherService service) =>
            {
                WeatherResponse content = await service.GetWeatherResponseAsync(city);

                if (content == null)
                    return Results.NotFound("Could not fetch weather");

                List<WeatherDTO> weatherDays = content.Days;

                return Results.Ok(weatherDays);



            });



        }



    }
}
