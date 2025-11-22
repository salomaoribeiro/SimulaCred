using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimulaCred.Infrastructure.Contexts;
using IContainer = DotNet.Testcontainers.Containers.IContainer;

namespace SimulaCred.IntegrationTests.Controllers.Simulacao;

public class SimulacaoAPIFactory: WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly string connectionString =
        "Server=localhost,1433;Database=SimulaCredDBIntegrationTest;User ID=sa;Password=YourStrongPassw0rd123;TrustServerCertificate=True;Encrypt=False";
    
    private readonly IContainer _container = new ContainerBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .WithEnvironment("ACCEPT_EULA", "Y")
        .WithEnvironment("SA_PASSWORD", "YourStrongPassw0rd123")
        .WithPortBinding(1433, 1433)
        .WithWaitStrategy(Wait.ForUnixContainer()
            .UntilExternalTcpPortIsAvailable(1433))
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        
        builder.ConfigureServices(services =>
        {
            var dbContextOptionsDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<SqlServerDbContext>));

            var dbContextDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(SqlServerDbContext));

            services.Remove(dbContextOptionsDescriptor!);
            services.Remove(dbContextDescriptor!);

            services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(connectionString));
        });
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
        
        using var conn = new SqlConnection(connectionString);
        for (int i = 0; i < 5; i++)
        {
            try
            {
                await conn.OpenAsync();
                break;
            }
            catch
            {
                await Task.Delay(5000);
            }
        }
    }

    public async Task DisposeAsync()
    {
        await _container.StopAsync();
    }
}