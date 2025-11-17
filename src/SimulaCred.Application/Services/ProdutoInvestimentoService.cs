using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Application.Interfaces.Services;
using SimulaCred.Domain.Entities;

namespace SimulaCred.Application.Services;

public class ProdutoInvestimentoService: IProdutoInvestimentoService

{
    private readonly IProdutoInvestimentoRepository _repository;


    public ProdutoInvestimentoService(IProdutoInvestimentoRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ProdutoInvestimento>> ListarProdutosAsync(CancellationToken cancellationToken) 
        => _repository.GetAllAsync(cancellationToken: cancellationToken);
}