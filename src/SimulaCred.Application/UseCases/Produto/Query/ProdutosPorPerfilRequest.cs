using MediatR;

namespace SimulaCred.Application.UseCases.Produto.Query;

public sealed record ProdutosPorPerfilRequest(string Perfil) :  IRequest<IEnumerable<ProdutosPorPerfilResponse>>;