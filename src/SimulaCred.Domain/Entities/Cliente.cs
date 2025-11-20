namespace SimulaCred.Domain.Entities;

public class Cliente: BaseEntity
{
    public int PreferenciaLiquidez { get; set; } // pensar em uma escala de 1 a 100
    public int PreferenciaRisco { get; set; }
}