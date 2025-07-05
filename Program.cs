namespace WeatherAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpClient<WeatherService>((sp, httpClient) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var apiKey = configuration["ApiKeys:WeatherApi"];
            });



            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapWeatherEndpoints();

            app.Run();


        }
    }
}
