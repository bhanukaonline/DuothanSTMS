using Duothan.Server.Data;
using Duothan.Server.Services;

namespace Duothan.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<TransportPassRepository>();
            builder.Services.AddScoped<UserRepository>();

            builder.Services.AddScoped<PublicTransportScheduleRepository>();
            builder.Services.AddScoped<VehicleLocationRepository>();
            builder.Services.AddScoped<ParkingInformationRepository>();
            builder.Services.AddScoped<StripeService>();
            builder.Services.AddScoped<PayPalService>();






            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/en.html");

            app.Run();
        }
    }
}
