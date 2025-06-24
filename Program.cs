namespace WeatherAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpClient<WeatherService>();


            var app = builder.Build();



            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapWeatherEndpoints();

            app.Run();


        }
    }
}
