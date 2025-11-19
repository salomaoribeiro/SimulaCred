using MediatR;

namespace SimulaCred.Application.UseCases.Simulacao.Query;

public sealed record SimulacaoRealizadaRequest() : IRequest<IEnumerable<SimulacaoRealizadaResponse>>;
