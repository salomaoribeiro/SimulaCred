using SimulaCred.Domain.Entities.Enums;

namespace SimulaCred.Domain.Entities;

public class ProdutoInvestimento: BaseEntity
{
    public string Nome { get; init; }
    public ProdutoInvestimentoTipo Tipo { get; init; }
    public float Rentabilidade { get; init; }
    public ProdutoInvestimentoRisco Risco { get; init; }
    bool Ativo { get; init; }

    public ProdutoInvestimento(string nome, ProdutoInvestimentoTipo tipo, float rentabilidade, ProdutoInvestimentoRisco risco)
    {
        Nome = nome;
        Tipo = tipo;
        Rentabilidade = rentabilidade;
        Risco = risco;
        Ativo = true;
    }
}