using MediatR;

namespace SimulaCred.Application.UseCases.Simulacao.Query;

public sealed record InvestimentosPorClienteResponse(int Id, string Tipo, decimal Valor, decimal Rentabilidade, string Data);