using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimulaCred.Domain.Entities.Enums;

public enum PerfilInvestidor
{
    [Description("O perfil ainda não fez nenhum investimento")]
    NaoInvestidor,
    
    [Description("Perfil com baixa movimentação e foco em liquidez")]
    Conservador,
    
    [Description("Perfil com equilíbrio entre liquidez e rentabilidade")]
    Moderado,
    
    [Description("Perfil que busca por alta rentabilidade e suporta maior risco")]
    Agressivo
}