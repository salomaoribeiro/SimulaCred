using MediatR;

namespace SimulaCred.Application.UseCases.Simulacao.Query;

public sealed record SimulacoesRealizadasRequest() : IRequest<IEnumerable<SimulacoesRealizadasResponse>>;
