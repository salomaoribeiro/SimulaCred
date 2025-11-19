namespace SimulaCred.Application.UseCases.Produto.Query;

public sealed record ListarProdutosResponse(
    string Nome,
    string Tipo,
    decimal Rentabilidade,
    string Risco,
    short PrazoMinimo,
    short? PrazoMaximo,
    bool Ativo);
