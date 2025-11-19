using MediatR;
using Microsoft.Extensions.Logging;
using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Domain.Entities.Enums;

namespace SimulaCred.Application.UseCases.Produto.Query;

public class ProdutosPorPerfilHandler: IRequestHandler<ProdutosPorPerfilRequest, IEnumerable<ProdutosPorPerfilResponse>>
{
    private readonly ILogger<ProdutosPorPerfilHandler> _logger;
    private readonly IProdutoInvestimentoRepository _produtoInvestimentoRepository;

    public ProdutosPorPerfilHandler(ILogger<ProdutosPorPerfilHandler> logger, IProdutoInvestimentoRepository produtoInvestimentoRepository)
    {
        _logger = logger;
        _produtoInvestimentoRepository = produtoInvestimentoRepository;
    }

    public async Task<IEnumerable<ProdutosPorPerfilResponse>> Handle(ProdutosPorPerfilRequest request, CancellationToken cancellationToken)
    {
        // TODO: acertar o motor de crédito para ajustar o perfil 
        var produtos =
            await _produtoInvestimentoRepository.GetAllAsync(cancellationToken, expression: p => p.Risco == ProdutoInvestimentoRisco.Baixo);
        return produtos.Select(p =>
            new ProdutosPorPerfilResponse(p.Id, p.Nome, p.Tipo.ToString(), p.Rentabilidade, p.Risco.ToString()));
    }
}