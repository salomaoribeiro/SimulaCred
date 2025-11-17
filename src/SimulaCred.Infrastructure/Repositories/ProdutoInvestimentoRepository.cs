using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Domain.Entities;
using SimulaCred.Infrastructure.Contexts;

namespace SimulaCred.Infrastructure.Repositories;

public class ProdutoInvestimentoRepository: BaseRepository<ProdutoInvestimento>, IProdutoInvestimentoRepository
{
    public ProdutoInvestimentoRepository(SqlServerDbContext context) : base(context)
    {
    }
}