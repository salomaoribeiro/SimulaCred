using FluentAssertions;

namespace SimulaCred.IntegrationTests.Controllers.Simulacao;

public class SimulacaoTestes : IClassFixture<SimulacaoAPIFactory>
{
    private readonly SimulacaoAPIFactory _apiFactory;

    public SimulacaoTestes(SimulacaoAPIFactory apiFactory)
    {
        _apiFactory = apiFactory;
    }
    
    [Fact]
    public async Task Simulacoes_DeveRetornarTodasSimulacoes()
    {
        var client = _apiFactory.CreateClient();
        
        var resultado = await client.GetAsync($"/simulacoes");
        string responseBody = await resultado.Content.ReadAsStringAsync();
        resultado.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}