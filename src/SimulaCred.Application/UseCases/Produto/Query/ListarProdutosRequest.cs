using MediatR;

namespace SimulaCred.Application.UseCases.Produto.Query;

public sealed record ListarProdutosRequest() : IRequest<IEnumerable<ListarProdutosResponse>>;
