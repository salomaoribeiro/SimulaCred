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
        var riscos = RiscosDoPerfil(request.Perfil.ToLower());

        var produtos = await _produtoInvestimentoRepository.GetAllAsync(cancellationToken,
            expression: p => p.Ativo && riscos.Contains(p.Risco), 
            orderBy: q=> q.OrderBy(p => p.Risco));

        return produtos.Select(p =>
            new ProdutosPorPerfilResponse(p.Id, p.Nome, p.Tipo.ToString(), p.Rentabilidade, p.Risco.ToString()));
    }

    private List<ProdutoInvestimentoRisco> RiscosDoPerfil(string perfil)
    {
        switch (perfil)
        {
            case "conservador":
                return new List<ProdutoInvestimentoRisco>() { ProdutoInvestimentoRisco.MuitoBaixo, ProdutoInvestimentoRisco.Baixo };
            
            case "moderado":
                return new List<ProdutoInvestimentoRisco>() { ProdutoInvestimentoRisco.Baixo, ProdutoInvestimentoRisco.Moderado };
            
            case "agressivo":
                return new List<ProdutoInvestimentoRisco>() { ProdutoInvestimentoRisco.Alto, ProdutoInvestimentoRisco.Inadimplencia };
            
            default:
                return new List<ProdutoInvestimentoRisco>()
                {
                    ProdutoInvestimentoRisco.MuitoBaixo, 
                    ProdutoInvestimentoRisco.Baixo,
                    ProdutoInvestimentoRisco.Moderado,
                    ProdutoInvestimentoRisco.Alto,
                    ProdutoInvestimentoRisco.Inadimplencia
                };
        }
    }
}