using PexelApiSearch.Application.PexelsServices.Implementations;
using PexelApiSearch.Application.PexelsServices.Interfaces;
using PexelApiSearch.Application.PexelsServices.Mappings;
using PexelApiSearch.Application.SearchHistoryServices.Implementations;
using PexelApiSearch.Application.SearchHistoryServices.Interfaces;
using PexelApiSearch.Infra.Database.Dapper;
using PexelApiSearch.Infra.Database.SearchHistory.Implementations;
using PexelApiSearch.Infra.PexelsExternalServices.Services.Implementations;
using PexelApiSearch.Infra.SearchHistoryServices.Repository;

namespace PexelsApiSearch.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHttpClient<IPexelsExternalService, PexelsExternalService>();
            builder.Services.AddAutoMapper(typeof(PexelsProfile));
            builder.Services.AddScoped<IPexelsSearchService, PexelsSearchService>();
            builder.Services.AddScoped<DatabaseInitializer>();
            builder.Services.AddScoped<DapperContext>();

            builder.Services.AddScoped<IGetSearchHistoryPagedHandler, GetSearchHistoryPagedHandler>();
            builder.Services.AddScoped<ICreateSearchHistoryHandler, CreateSearchHistoryHandler>();
            builder.Services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();

#if(DEBUG)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    policy => policy
                        .WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
#endif
            var app = builder.Build();

#if(DEBUG)
            app.UseCors("AllowLocalhost");
#endif

            using (var scope = app.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
                await initializer.InitializeAsync();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();






            app.Run();
        }
    }
}
