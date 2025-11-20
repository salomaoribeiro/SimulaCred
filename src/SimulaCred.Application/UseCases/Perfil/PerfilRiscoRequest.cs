using MediatR;

namespace SimulaCred.Application.UseCases.Perfil;

public sealed record PerfilRiscoRequest(int clientId) : IRequest<PerfilRiscoResponse>;