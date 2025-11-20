namespace SimulaCred.Domain.Entities;

public class Telemetria : BaseEntity
{
    public Telemetria(string nome, long tempo)
    {
        Nome = nome;
        Tempo = tempo;
        CreatedAt = DateTime.UtcNow;
    }

    public string Nome { get; init; }
    public long Tempo { get; init; }
}