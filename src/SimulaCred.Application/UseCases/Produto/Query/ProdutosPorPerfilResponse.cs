namespace SimulaCred.Application.UseCases.Produto.Query;

public sealed record ProdutosPorPerfilResponse(int Id, string Nome, string Tipo, decimal Rentabilidade, string Risco);