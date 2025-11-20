using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.UseCases.Simulacao.Command;
using SimulaCred.Application.UseCases.Simulacao.Query;
using SimulaCred.Application.UseCases.Telemetria.Command;
using SimulaCred.Domain.Entities;

namespace SimulaCred.API.Controllers;

[ApiController]
// [Route("[controller]")]
public class SimulacaoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<SimulacaoController> _logger;

    public SimulacaoController(ILogger<SimulacaoController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("/simular-investimento")]
    public async Task<ActionResult<IEnumerable<ProdutoInvestimento>>> SimularInvestimento([FromBody] SimularInvestimentoRequest request, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return Ok(await _mediator.Send(
                new SimularInvestimentoRequest(request.ClienteId, request.Valor, request.PrazoMeses,
                    request.TipoProduto), cancellationToken));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Problem("Erro ao tentar executar a requisição.");
        }
        finally
        {
            sw.Stop();
            await _mediator.Send(new SalvarTelemetriaRequest("/simular-investimento",  sw.ElapsedMilliseconds), cancellationToken);
        }
    }

    [HttpGet("/simulacoes")]
    public async Task<ActionResult<IEnumerable<SimulacoesRealizadasResponse>>> Simulacoes(CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return Ok(await _mediator.Send(new SimulacoesRealizadasRequest(), cancellationToken));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Problem("Erro ao tentar executar a requisição.");
        }
        finally
        {
            sw.Stop();
            await _mediator.Send(new SalvarTelemetriaRequest("/simulacoes",  sw.ElapsedMilliseconds), cancellationToken);
        }
    }

    [HttpGet("/simulacoes/por-produto-dia")]
    public async Task<ActionResult<IEnumerable<SimulacaoPorDiaResponse>>> SimulacoesPorDia(CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return Ok(await _mediator.Send(new SimulacaoPorDiaRequest(), cancellationToken));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Problem("Erro ao tentar executar a requisição.");
        }
        finally
        {
            sw.Stop();
            await _mediator.Send(new SalvarTelemetriaRequest("/simulacoes/por-produto-dia",  sw.ElapsedMilliseconds), cancellationToken);
        }
    }
}
