using MediatR;
using Microsoft.Extensions.Logging;
using SimulaCred.Application.Extensions;
using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Domain.Entities;
using SimulaCred.Domain.Entities.Enums;

namespace SimulaCred.Application.UseCases.Perfil;

public class PerfilRiscoHandler : IRequestHandler<PerfilRiscoRequest, PerfilRiscoResponse>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly ISimulacaoRepository _simulacaoRepository;
    private readonly ILogger<PerfilRiscoHandler> _logger;

    public PerfilRiscoHandler(IClienteRepository clienteRepository, ILogger<PerfilRiscoHandler> logger, ISimulacaoRepository simulacaoRepository)
    {
        _clienteRepository = clienteRepository;
        _simulacaoRepository = simulacaoRepository;
        _logger = logger;
    }

    public async Task<PerfilRiscoResponse> Handle(PerfilRiscoRequest request, CancellationToken cancellationToken)
    {
        // Motor de Recomendação:
        // o Algoritmo simples baseado em:
        //     ▪ Volume de investimentos
        //     ▪ Frequência de movimentações
        //     ▪ Preferência por liquidez ou rentabilidade
            
        // regras simples: o total investido + frequencia de historicos + preferencia do cliente
        // tentar colocar peso nos 3 tópicos acima (volume 40, frequencia 30 e preferencia 30)
        var clientes = await _clienteRepository.GetAllAsync(
            cancellationToken: cancellationToken,
            c => c.ClientId == request.clientId);

        // não estou usando o clientId como Id da entidade no banco.
        Cliente cliente;

        if (clientes.Any())
            cliente = await _clienteRepository.GetByIdAsync(clientes.First().Id, cancellationToken);
        else
        {
            cliente = new Cliente() { ClientId = request.clientId };
            await _clienteRepository.AddAsync(cliente, cancellationToken);
        }
        
        // TODO: olhar ação para nenhum investimento
        // TODO: O que fazer com as simulaçoes que não tem produto?
        // (talvez uma flag para dizer que não tinha produto correspondido? - pensar nisso)
        var simulacoes = await _simulacaoRepository.GetAllAsync(
            cancellationToken: cancellationToken,
            s => s.ClientId == request.clientId,
            includeProperties: p => p.Produto);
        
        var totalInvestido = simulacoes.ToList().Sum(h => h.ValorInvestido);
        var frequencia = simulacoes.Count();
        
        var score = 0;
        
        // calculo super simples apenas para simular
        // volume total que o cliente investiu (peso 40)
        if (totalInvestido > 140_000) score += 40;
        else if (totalInvestido > 25_000) score += 25;
        else if (totalInvestido > 0) score += 10;
        else score += 0;

        // frequencia com que o cliente investiu (peso 30)
        if (frequencia >= 12) score += 30;
        else if (frequencia >= 4) score += 15;
        else if (frequencia >= 1) score += 5;
        else score += 0;

        // preferencia do cliente (peso 30) - preferenciaRisco 0..100 analisando no que ele mais investiu
        var maisInvestiuPorGrupo = simulacoes
            .GroupBy(x => x.Produto.Risco)
            .OrderByDescending(x => x.Key)
            .FirstOrDefault();

        var maiorRisco = maisInvestiuPorGrupo?.Key ?? 0;
            
        score += (int)Math.Round((int) maiorRisco * 0.3);

        PerfilInvestidor perfil;
        if (score == 0) perfil = PerfilInvestidor.NaoInvestidor;
        else if (score < 40) perfil = PerfilInvestidor.Conservador;
        else if (score < 70) perfil = PerfilInvestidor.Moderado;
        else perfil = PerfilInvestidor.Agressivo;

        var retorno = new PerfilRiscoResponse
        (
            ClienteId: request.clientId,
            Perfil: perfil.ToString(),
            Pontuacao: score,
            Descricao: perfil.ObterDescricao()
        );

        // Atualizar o perfil do cliente com o novo perfil dele
        cliente.Pontuacao = score;
        cliente.PerfilInvestidor = perfil;
        cliente.PreferenciaRisco = (int)maiorRisco;
        
        await _clienteRepository.UpdateAsync(cliente, cancellationToken);

        return retorno;
    }
}