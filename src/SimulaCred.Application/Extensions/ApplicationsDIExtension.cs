using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SimulaCred.Application.Extensions;

public static class ApplicationsDIExtension
{
    public static void ConfigureApplicationDI(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
