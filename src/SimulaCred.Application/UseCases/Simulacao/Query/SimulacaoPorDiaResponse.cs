namespace SimulaCred.Application.UseCases.Simulacao.Query;

public sealed record SimulacaoPorDiaResponse(string Produto, string Data, int QuantidadeSimulacoes, decimal mediaValorFinal);