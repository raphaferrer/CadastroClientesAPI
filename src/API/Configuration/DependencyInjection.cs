using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using System.Data;
using Microsoft.Data.SqlClient;
using Domain.Interfaces;

namespace API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
