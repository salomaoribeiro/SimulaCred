namespace SimulaCred.Application.UseCases.Perfil;

public sealed record PerfilRiscoResponse(int ClienteId, string Perfil, int Pontuacao, string Descricao);