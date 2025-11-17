using SimulaCred.Domain.Entities;

namespace SimulaCred.Application.Interfaces.Services;

public interface IProdutoInvestimentoService
{
    Task<IEnumerable<ProdutoInvestimento>> ListarProdutosAsync(CancellationToken cancellationToken);
}