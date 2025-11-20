using SimulaCred.Domain.Entities.Enums;

namespace SimulaCred.Domain.Entities;

public class Cliente: BaseEntity
{
    public int ClientId { get; init; }
    public PerfilInvestidor PerfilInvestidor { get; set; }
    public int Pontuacao { get; set; }
    public int PreferenciaLiquidez { get; set; } // pensar em uma escala de 1 a 100
    public int PreferenciaRisco { get; set; }
}