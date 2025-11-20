using MediatR;
using Microsoft.Extensions.Logging;
using SimulaCred.Application.Interfaces.Repositories;

namespace SimulaCred.Application.UseCases.Telemetria.Command;

public class SalvarTelemetriaHandle : IRequestHandler<SalvarTelemetriaRequest>
{
    private readonly ILogger<SalvarTelemetriaHandle> _logger;
    private readonly ITelemetriaRepository _telemetriaRepository;

    public SalvarTelemetriaHandle(ITelemetriaRepository telemetriaRepository, ILogger<SalvarTelemetriaHandle> logger)
    {
        _telemetriaRepository = telemetriaRepository;
        _logger = logger;
    }

    public async Task Handle(SalvarTelemetriaRequest request, CancellationToken cancellationToken)
    {
        await _telemetriaRepository.AddAsync(
            new Domain.Entities.Telemetria(
                nome: request.Nome, 
                tempo: request.Tempo)
            , cancellationToken: cancellationToken
        );
    }
}