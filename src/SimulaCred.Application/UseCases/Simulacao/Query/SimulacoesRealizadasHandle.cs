using MediatR;
using Microsoft.Extensions.Logging;
using SimulaCred.Application.Interfaces.Repositories;

namespace SimulaCred.Application.UseCases.Simulacao.Query;

public class SimulacoesRealizadasHandle: IRequestHandler<SimulacoesRealizadasRequest, IEnumerable<SimulacoesRealizadasResponse>>
{
    private readonly ISimulacaoRepository _repository;
    private readonly ILogger<SimulacoesRealizadasHandle> _logger;

    public SimulacoesRealizadasHandle(ISimulacaoRepository repository, ILogger<SimulacoesRealizadasHandle> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<SimulacoesRealizadasResponse>> Handle(SimulacoesRealizadasRequest request, CancellationToken cancellationToken)
    {
        var simulacoes = await _repository.GetAllAsync(cancellationToken, includeProperties: p => p.Produto);

        var retorno = simulacoes.Select(s =>
            new SimulacoesRealizadasResponse(s.Id, s.ClientId, s.Produto.Nome, s.ValorInvestido, s.ValorFinal,
                s.PrazoInvestimento, s.CreatedAt));
        return retorno;
    }
}