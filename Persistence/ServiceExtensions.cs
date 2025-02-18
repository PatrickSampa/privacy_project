using CleanArchitectureDomain.Interfaces;
using CleanArchtecture.Persistence.Context;
using CleanArchtecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CleanArchtecture.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigPersistenceApp(this IServiceCollection services, IConfiguration configuration) 
        {

            var postgresConnectionString = configuration.GetConnectionString("PostgreSQL");
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(postgresConnectionString));

            var mongoConnectionString = configuration.GetConnectionString("MongoDB");
            var mongoDataBaseName = configuration["MongoDBSettings:teste"];
            var mongoClient = new MongoClient(mongoConnectionString);
            services.AddSingleton<IMongoClient>(mongoClient);
            services.AddScoped(provider =>
            {
                var client = provider.GetService<IMongoClient>();
                return client.GetDatabase(mongoDataBaseName) as IMongoDatabase;
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UseRepository>();
        }
    }
}
