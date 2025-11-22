using System.Threading;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using Xunit;
using SimulaCred.Application.UseCases.Telemetria.Command;
using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Domain.Entities;

namespace SimulaCred.UnitTests.Application.UseCases;

public class SalvarTelemetriaHandleTests
{
	[Fact]
	public async Task SalvarTelemetria_DeveChamarORepositorioAddAsyncComAEntidadeCorreta()
	{
		var telemetriaRepoMock = new Mock<ITelemetriaRepository>();
		var loggerMock = new Mock<ILogger<SalvarTelemetriaHandle>>();

		var handler = new SalvarTelemetriaHandle(telemetriaRepoMock.Object, loggerMock.Object);

		var request = new SalvarTelemetriaRequest("/minha-rota", 150L);

		await handler.Handle(request, CancellationToken.None);

		telemetriaRepoMock.Verify(r => r.AddAsync(
			It.Is<Telemetria>(t => t.Nome == request.Nome && t.Tempo == request.Tempo),
			It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact]
	public async Task SalvarTelemetria_DeveLancarExcecao()
	{
		var telemetriaRepoMock = new Mock<ITelemetriaRepository>();
		var loggerMock = new Mock<ILogger<SalvarTelemetriaHandle>>();

		telemetriaRepoMock.Setup(r => r.AddAsync(It.IsAny<Telemetria>(), It.IsAny<CancellationToken>()))
			.ThrowsAsync(new System.InvalidOperationException("db error"));

		var handler = new SalvarTelemetriaHandle(telemetriaRepoMock.Object, loggerMock.Object);

		var request = new SalvarTelemetriaRequest("/erro", 10L);

		await Assert.ThrowsAsync<System.InvalidOperationException>(() => handler.Handle(request, CancellationToken.None));
	}
}