using MediatR;
using SimulaCred.Domain.Entities.Enums;

namespace SimulaCred.Application.UseCases.Produto.Query;

public sealed record ProdutosPorPerfilRequest(PerfilInvestidor Perfil) :  IRequest<IEnumerable<ProdutosPorPerfilResponse>>;