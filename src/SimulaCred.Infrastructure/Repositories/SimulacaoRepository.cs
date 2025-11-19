using Microsoft.EntityFrameworkCore;
using SimulaCred.Domain.Entities;
using SimulaCred.Infrastructure.Contexts;
using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Application.UseCases.Simulacao.Query;

namespace SimulaCred.Infrastructure.Repositories;

public class SimulacaoRepository : BaseRepository<Simulacao>, ISimulacaoRepository
{
    private readonly SqlServerDbContext _context;
    public SimulacaoRepository(SqlServerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SimulacaoPorDiaResponse>> BuscarTodosPorDia()
    {
        var simulacoes = _context.Simulacoes
            .Include(s => s.Produto)
            .GroupBy(s => new 
            { 
                ProdutoNome = s.Produto.Nome, 
                Data = s.CreatedAt.Date 
            })
            .Select(g => new 
            {
                Produto = g.Key.ProdutoNome,
                Data = g.Key.Data,
                Quantidade = g.Count(),
                MediaValorFinal = g.Average(s => s.ValorFinal)
            })
            .ToList();
        
        var retorno = simulacoes.Select(s =>
            new SimulacaoPorDiaResponse(s.Produto, s.Data.ToString(), s.Quantidade, s.MediaValorFinal));
        
        return await Task.FromResult(retorno);
    }
}
