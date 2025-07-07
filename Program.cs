using StackExchange.Redis;

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

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");


            builder.Services.AddSingleton<IConnectionMultiplexer>(redis);
            builder.Services.AddScoped(s => s.GetRequiredService<IConnectionMultiplexer>().GetDatabase());

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapWeatherEndpoints();

            app.Run();


        }
    }
}
