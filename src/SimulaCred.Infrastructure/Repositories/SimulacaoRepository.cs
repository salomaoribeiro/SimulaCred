using Microsoft.EntityFrameworkCore;
using SimulaCred.Domain.Entities;
using SimulaCred.Infrastructure.Contexts;
using SimulaCred.Application.Interfaces.Repositories;

namespace SimulaCred.Infrastructure.Repositories;

public class SimulacaoRepository : BaseRepository<Simulacao>, ISimulacaoRepository
{
    public SimulacaoRepository(SqlServerDbContext context) : base(context)
    {
    }
}
