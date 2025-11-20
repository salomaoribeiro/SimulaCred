using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Domain.Entities;
using SimulaCred.Infrastructure.Contexts;

namespace SimulaCred.Infrastructure.Repositories;

public class TelemetriaRepository: BaseRepository<Telemetria>, ITelemetriaRepository
{
    public TelemetriaRepository(SqlServerDbContext context) : base(context)
    {
    }
}