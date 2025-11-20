namespace SimulaCred.Application.UseCases.Simulacao.Query;

public sealed record SimulacoesRealizadasResponse(int Id, int ClientId, string Produto, decimal ValorInvestido, decimal ValorFinal, int PrazoMeses, DateTime DataSimulacao);
