using Microsoft.EntityFrameworkCore;
using SimulaCred.Domain.Entities;

namespace SimulaCred.Infrastructure.Contexts;

public class SqlServerDbContext: DbContext
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {
    }
    
    DbSet<ProdutoInvestimento> ProdutoInvestimento { get; set; }
}