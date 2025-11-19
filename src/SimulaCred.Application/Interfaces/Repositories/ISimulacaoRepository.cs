using SimulaCred.Application.UseCases.Simulacao.Query;
using SimulaCred.Domain.Entities;

namespace SimulaCred.Application.Interfaces.Repositories;

public interface ISimulacaoRepository : IBaseRepository<Simulacao>
{
    Task<IEnumerable<SimulacaoPorDiaResponse>> BuscarTodosPorDia();
}
