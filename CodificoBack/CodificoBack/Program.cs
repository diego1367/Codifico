
using CodificoBack.MiddleWare;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CodificoBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.Configure<Connection>(builder.Configuration.GetSection("ConnectionStrings"));
            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
            IoC.AddDependency(builder.Services, builder.Configuration);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseCors("corsapp");
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseSwaggerUI(o => o.SwaggerEndpoint("/openapi/v1.json", "Swagger Demo"));
            app.UseCors("corsapp");
            app.MapControllers();

            app.Run();
        }
    }
}
