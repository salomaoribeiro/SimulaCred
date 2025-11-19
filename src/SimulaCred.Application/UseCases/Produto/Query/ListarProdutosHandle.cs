using MediatR;
using SimulaCred.Application.Interfaces.Repositories;

namespace SimulaCred.Application.UseCases.Produto.Query;

public class ListarProdutosHandle : IRequestHandler<ListarProdutosRequest, IEnumerable<ListarProdutosResponse>>
{
    private readonly IProdutoInvestimentoRepository _produtoRepository;

    public ListarProdutosHandle(IProdutoInvestimentoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<IEnumerable<ListarProdutosResponse>> Handle(ListarProdutosRequest request, CancellationToken cancellationToken)
    {
        var produtos = await _produtoRepository.GetAllAsync(cancellationToken);
        var retorno = produtos.Select(p =>
            new ListarProdutosResponse(
              p.Nome,
              p.Tipo.ToString(),
              p.Rentabilidade,
              p.Risco.ToString(),
              p.PrazoMinimo,
              p.PrazoMaximo,
              p.Ativo
            )
        );
        return retorno;
    }
}
