using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Application.Interfaces.Services;
using SimulaCred.Application.Services;

namespace SimulaCred.Application.Extensions;

public static class ApplicationsDIExtension
{
    public static void ConfigureApplicationDI(this IServiceCollection services)
    {
        services.AddScoped<IProdutoInvestimentoService, ProdutoInvestimentoService>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
