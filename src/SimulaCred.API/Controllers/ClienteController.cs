using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.UseCases.Simulacao.Query;
using SimulaCred.Application.UseCases.Telemetria.Command;

namespace SimulaCred.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProdutoInvestimentoController> _logger;


    public ClienteController(IMediator mediator, ILogger<ProdutoInvestimentoController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpGet("/investimentos/{clienteId}")]
    public async Task<ActionResult<IEnumerable<InvestimentosPorClienteResponse>>> Simulacoes([FromRoute] int clienteId, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return Ok(await _mediator.Send(new InvestimentosPorClienteRequest(clienteId), cancellationToken));
        }
        catch (Exception e)
        {
            return Problem("Erro ao tentar executar a requisição.");
        }
        finally
        {
            sw.Stop();
            await _mediator.Send(new SalvarTelemetriaRequest("/investimentos",  sw.ElapsedMilliseconds), cancellationToken);
        }
    } 
}