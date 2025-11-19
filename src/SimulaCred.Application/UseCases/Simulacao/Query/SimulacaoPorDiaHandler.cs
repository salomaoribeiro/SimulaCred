using MediatR;
using Microsoft.Extensions.Logging;
using SimulaCred.Application.Interfaces.Repositories;

namespace SimulaCred.Application.UseCases.Simulacao.Query;

public class SimulacaoPorDiaHandler : IRequestHandler<SimulacaoPorDiaRequest, IEnumerable<SimulacaoPorDiaResponse>>
{
    private readonly ISimulacaoRepository _repository;
    private readonly ILogger<SimulacaoPorDiaHandler> _logger;

    public SimulacaoPorDiaHandler(ILogger<SimulacaoPorDiaHandler> logger, ISimulacaoRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<IEnumerable<SimulacaoPorDiaResponse>> Handle(SimulacaoPorDiaRequest request, CancellationToken cancellationToken)
    {
        var simulacoes = await _repository.BuscarTodosPorDia();
        return simulacoes;
    }
}