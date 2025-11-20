using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Domain.Entities;
using SimulaCred.Infrastructure.Contexts;

namespace SimulaCred.Infrastructure.Repositories;

public class ClienteRepository: BaseRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(SqlServerDbContext context) : base(context)
    {
    }
}