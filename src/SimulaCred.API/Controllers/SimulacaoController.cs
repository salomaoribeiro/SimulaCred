using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.UseCases.Produto.Query;
using SimulaCred.Application.UseCases.Simulacao.Command;
using SimulaCred.Application.UseCases.Simulacao.Query;
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
        return Ok(await _mediator.Send(new SimularInvestimentoRequest(request.ClienteId, request.Valor, request.PrazoMeses, request.TipoProduto), cancellationToken));
    }

    [HttpGet("/simulacoes")]
    public async Task<IEnumerable<SimulacaoRealizadaResponse>> Simulacoes(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new SimulacaoRealizadaRequest(), cancellationToken);
    }

    [HttpGet("/simulacoes/por-produto-dia")]
    public async Task<IEnumerable<SimulacaoPorDiaResponse>> SimulacoesPorDia(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new SimulacaoPorDiaRequest(), cancellationToken);
    }
}
