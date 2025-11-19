using MediatR;
using SimulaCred.Application.Interfaces.Repositories;

namespace SimulaCred.Application.UseCases.Simulacao.Query;

public class InvestimentoPorClienteHandler: IRequestHandler<InvestimentosPorClienteRequest, IEnumerable<InvestimentosPorClienteResponse>>
{
    private readonly ISimulacaoRepository _simulacaoRepository;

    public InvestimentoPorClienteHandler(ISimulacaoRepository simulacaoRepository)
    {
        _simulacaoRepository = simulacaoRepository;
    }

    public async Task<IEnumerable<InvestimentosPorClienteResponse>> Handle(InvestimentosPorClienteRequest request, CancellationToken cancellationToken)
    {
        var simulacoes = await _simulacaoRepository.GetAllAsync(
            cancellationToken, 
            expression: s => s.ClientId == request.ClientId, 
            includeProperties: s => s.Produto
        );
        
        return simulacoes.Select(s => 
            new InvestimentosPorClienteResponse(
                s.Id, 
                s.Produto.Tipo.ToString(), 
                s.ValorInvestido, 
                s.Produto.Rentabilidade, 
                s.CreatedAt.ToString("yyyy-MM-dd"))
        );
    }
}