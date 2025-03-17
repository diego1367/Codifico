using CodficoBack.Data.Context;
using CodificoBack.Business.Implementation;
using CodificoBack.Business.Interfaces;
using CodificoBack.Repository;
using Microsoft.EntityFrameworkCore;

namespace CodificoBack.MiddleWare
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ContextDb>(db =>
            db.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                    );
            }));

            services.AddScoped<IUnitOfWork>(sp => new UnitOfWork(
                sp.GetRequiredService<DbContextOptions<ContextDb>>(),
                sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")));
            services.AddScoped<ISales, Sales>();
            return services;
        }
    }
}

