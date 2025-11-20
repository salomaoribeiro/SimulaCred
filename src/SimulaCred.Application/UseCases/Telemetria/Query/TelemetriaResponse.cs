namespace SimulaCred.Application.UseCases.Telemetria.Query;

public sealed record TelemetriaResponse(List<Servicos> servicos, Periodo periodo);

public sealed record Servicos(string Nome, int QuantidadeChamadas, long MediaTempoRespostaMS);

public sealed record Periodo(string Inicio, string Fim);