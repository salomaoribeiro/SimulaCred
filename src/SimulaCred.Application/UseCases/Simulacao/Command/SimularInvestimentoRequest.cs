using MediatR;

namespace SimulaCred.Application.UseCases.Simulacao.Command;

public sealed record SimularInvestimentoRequest(
    int ClienteId,
    decimal Valor,
    int PrazoMeses,
    string TipoProduto) : IRequest<SimularInvestimentoResponse>;
