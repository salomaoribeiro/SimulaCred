using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimulaCred.Domain.Interfaces;
using SimulaCred.Infrastructure.Contexts;
using SimulaCred.Infrastructure.Repositories;

namespace SimulaCred.Infrastructure.Extensions;

public static class InfrastructureDIRegistrationExtension
{
    public static void ConfigureInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
    {
        // Contextos
        services.AddDbContext<SqlServerDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("SqlServer"))
        );
        
        // Repositórios
        services.AddScoped<IProdutoInvestimentoRepository, ProdutoInvestimentoRepository>();
    }
}