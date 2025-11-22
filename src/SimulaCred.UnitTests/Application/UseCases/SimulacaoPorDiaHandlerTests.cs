
using Moq;
using Microsoft.Extensions.Logging;
using SimulaCred.Application.UseCases.Simulacao.Query;
using SimulaCred.Application.Interfaces.Repositories;

namespace SimulaCred.UnitTests.Application.UseCases.Simulacao;

public class SimulacaoPorDiaHandlerTests
{
    [Fact]
    public async Task SimulacaoPorDia_DeveRetornarAsSimulacoes()
    {
        var loggerMock = new Mock<ILogger<SimulacaoPorDiaHandler>>();
        var simulacaoRepoMock = new Mock<ISimulacaoRepository>();

        simulacaoRepoMock.Setup(r => r.BuscarTodosPorDia())
            .ReturnsAsync(new List<SimulacaoPorDiaResponse>());

        var handler = new SimulacaoPorDiaHandler(loggerMock.Object, simulacaoRepoMock.Object);

        var request = new SimulacaoPorDiaRequest();

        var result = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
    }
}