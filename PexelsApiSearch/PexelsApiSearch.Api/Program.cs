using PexelApiSearch.Application.Mappings;
using PexelApiSearch.Application.PexelsServices.Implementations;
using PexelApiSearch.Application.PexelsServices.Interfaces;
using PexelApiSearch.Infra.PexelsExternalServices.Services.Implementations;

namespace PexelsApiSearch.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHttpClient<IPexelsExternalService, PexelsExternalService>();
            builder.Services.AddAutoMapper(typeof(PexelsProfile));
            builder.Services.AddScoped<IPexelsSearchService, PexelsSearchService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
