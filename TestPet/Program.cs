using CitrusWeb.Api.DataAccess;
using CitrusWeb.Shared.Services;
using Services.Presentation;
using Services.Video;
using System.Text.Json.Serialization;

namespace CitrusWeb.Api
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200",
                                                         "http://localhost");
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();
                                      policy.AllowCredentials();
                                  });
            });

            // Add services to the container.

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLogging();

            if(builder.Environment.IsProduction())
            {
                builder.Services.AddTransient<IDataAccessConfig, DataAccessConfigProd>();
            }
            else
            {
                builder.Services.AddTransient<IDataAccessConfig, DataAccessConfigDev>();
            }

            builder.Services.AddScoped<IUnitOfWork, CitrusUnitOfWork>();
            builder.Services.AddTransient<IVideoService, VideoService>();

            builder.Services.AddTransient<IPresentationService, PresentationService>();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                var jsonConverter = new JsonStringEnumConverter();
                options.JsonSerializerOptions.Converters.Add(jsonConverter);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyAllowSpecificOrigins");

            app.MapControllers();
            
            app.Run();
        }
    }
}
