namespace SimulaCred.Domain.Entities;

public class Simulacao : BaseEntity
{
    public int ClientId { get; init; }
    public int ProdutoId { get; set; }
    public virtual ProdutoInvestimento Produto { get; set; }
    public decimal ValorInvestido { get; init; }
    public decimal ValorFinal { get; set; }
    public int PrazoInvestimento { get; init; }

    public Simulacao(int clientId, int produtoId, decimal valorInvestido, decimal valorFinal, int prazoInvestimento)
    {
        ClientId = clientId;
        ProdutoId = produtoId;
        ValorInvestido = valorInvestido;
        ValorFinal = valorFinal;
        PrazoInvestimento = prazoInvestimento;
        CreatedAt = DateTime.UtcNow;
    }
}