using MediatR;

namespace SimulaCred.Application.UseCases.Telemetria.Command;

public sealed record SalvarTelemetriaRequest(string Nome, long Tempo) : IRequest;