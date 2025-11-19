using SimulaCred.Domain.Entities.Enums;

namespace SimulaCred.Domain.Entities;

public class ProdutoInvestimento : BaseEntity
{
    public string Nome { get; init; }
    public ProdutoInvestimentoTipo Tipo { get; init; }
    public decimal Rentabilidade { get; init; }
    public ProdutoInvestimentoRisco Risco { get; init; }
    public short PrazoMinimo { get; init; }
    public short? PrazoMaximo { get; init; }
    public bool Ativo { get; set; }

    public ProdutoInvestimento(
        string nome,
        ProdutoInvestimentoTipo tipo,
        decimal rentabilidade,
        ProdutoInvestimentoRisco risco,
        short prazoMinimo,
        short? prazoMaximo)
    {
        Nome = nome;
        Tipo = tipo;
        Rentabilidade = rentabilidade;
        Risco = risco;
        Ativo = true;
        PrazoMinimo = prazoMinimo;
        PrazoMaximo = prazoMaximo;
    }
}
