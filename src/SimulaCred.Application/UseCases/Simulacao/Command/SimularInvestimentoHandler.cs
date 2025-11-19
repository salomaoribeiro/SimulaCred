using MediatR;
using SimulaCred.Domain.Entities;
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


    public async Task<SimularInvestimentoResponse> Handle(SimularInvestimentoRequest request, CancellationToken cancellationToken)
    {
        var produtos = await _produtoRepository.GetAllAsync(
            cancellationToken); //,
        var produto = produtos.FirstOrDefault(p => request.TipoProduto.ToLower().Contains(p.Tipo.ToString().ToLower())
                                                   && (p.PrazoMinimo <= request.PrazoMeses && p.PrazoMaximo >= request.PrazoMeses)
                                                   && p.Tipo.ToString().ToLower().Contains(request.TipoProduto.ToLower()));

        // TODO: Validar se não tem produto caso contrário dará erro
        // if (produtos.Any())
        var simulacao = new Domain.Entities.Simulacao(request.ClienteId, produto.Id,request.Valor, request.Valor * produto.Rentabilidade + request.Valor, request.PrazoMeses);
        await _simulacaoRepository.AddAsync(simulacao, cancellationToken);
        
        return new SimularInvestimentoResponse(
            new ProdutoValidado(produto.Id, produto.Nome, produto.Tipo.ToString(), produto.Rentabilidade, produto.Risco.ToString()), 
            new ResultadoSimulacao(request.Valor * produto.Rentabilidade, produto.Rentabilidade, request.PrazoMeses), 
            new DateTime()
        );
    }
}
