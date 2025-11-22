using MediatR;
using Microsoft.Extensions.Logging;
using SimulaCred.Application.Interfaces.Repositories;

namespace SimulaCred.Application.UseCases.Simulacao.Command;

public class SimularInvestimentoHandler : IRequestHandler<SimularInvestimentoRequest, SimularInvestimentoResponse>
{
    private readonly IProdutoInvestimentoRepository _produtoRepository;
    private readonly ISimulacaoRepository _simulacaoRepository;
    private readonly ILogger<SimularInvestimentoHandler> _logger;

    public SimularInvestimentoHandler(ILogger<SimularInvestimentoHandler> logger, IProdutoInvestimentoRepository produtoRepository, ISimulacaoRepository simulacaoRepository)
    {
        _logger = logger;
        _produtoRepository = produtoRepository;
        _simulacaoRepository = simulacaoRepository;
    }


    public async Task<SimularInvestimentoResponse> Handle(SimularInvestimentoRequest request, CancellationToken cancellationToken = default)
    {
        var produtos = await _produtoRepository.GetAllAsync(
            cancellationToken);
        
        // TODO: mudar o tipo de string para enum
        var produto = produtos.FirstOrDefault(p => 
            // request.TipoProduto.ToLower().Contains(p.Tipo.ToString().ToLower()) 
            p.Tipo.ToString().ToLower().Contains(request.TipoProduto.ToLower())
            && (p.PrazoMinimo <= request.PrazoMeses && p.PrazoMaximo >= request.PrazoMeses)
        );

        // TODO: Validar se não tem produto caso contrário dará erro
        // if (!produtos.Any())
            // return new SimularInvestimentoResponse(new ProdutoValidado(), new ResultadoSimulacao(), sim);
        
        
        var simulacao = new Domain.Entities.Simulacao(
            clientId: request.ClienteId,
            produtoId: produto.Id,
            valorInvestido: request.Valor, 
            valorFinal: (request.Valor * produto.Rentabilidade) + request.Valor, 
            prazoInvestimento: request.PrazoMeses);
        
        await _simulacaoRepository.AddAsync(simulacao, cancellationToken);
        
        var teste =  new SimularInvestimentoResponse(
            new ProdutoValidado(
                id: simulacao.Id, 
                nome: produto.Nome,
                tipo: produto.Tipo.ToString(), 
                rentabilidade: produto.Rentabilidade, 
                risco: produto.Risco.ToString()),
            new ResultadoSimulacao(
                valorFinal: (request.Valor * produto.Rentabilidade) + request.Valor,
                rentabilidadeEfetiva: produto.Rentabilidade, 
                prazoMeses: request.PrazoMeses),
            DataSimulacao: simulacao.CreatedAt
        );

        return teste;
    }
}
