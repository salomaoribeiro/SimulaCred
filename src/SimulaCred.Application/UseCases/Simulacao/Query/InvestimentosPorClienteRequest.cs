using MediatR;

namespace SimulaCred.Application.UseCases.Simulacao.Query;

public sealed record InvestimentosPorClienteRequest(int ClientId) : IRequest<IEnumerable<InvestimentosPorClienteResponse>>;