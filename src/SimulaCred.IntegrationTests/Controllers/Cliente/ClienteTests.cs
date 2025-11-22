using FluentAssertions;

namespace SimulaCred.IntegrationTests.Controllers.Cliente;

public class ClienteTests : IClassFixture<ClienteAPIFactory>
{
    private readonly ClienteAPIFactory _apiFactory;

    public ClienteTests(ClienteAPIFactory apiFactory)
    {
        _apiFactory = apiFactory;
    }

    [Fact]
    public async Task InvestimentosPorCliente_DeveRetornarVazio()
    {
        var client = _apiFactory.CreateClient();

        var clientId = 1;
        
        var resultado = await client.GetAsync($"/investimentos/{clientId}");
        string responseBody = await resultado.Content.ReadAsStringAsync();
        resultado.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        responseBody.Should().Be("[]");
    }
}