using MediatR;

namespace SimulaCred.Application.UseCases.Telemetria.Query;

public sealed record TelemetriaRequest(DateTime DataInicio, DateTime DataFim) : IRequest<TelemetriaResponse>;