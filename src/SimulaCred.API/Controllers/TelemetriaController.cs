using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.UseCases.Telemetria.Command;
using SimulaCred.Application.UseCases.Telemetria.Query;

namespace SimulaCred.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TelemetriaController: ControllerBase
{
    private readonly ILogger<TelemetriaController> _logger;
    private readonly IMediator _mediator;

    public TelemetriaController(ILogger<TelemetriaController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("/telemetria")]
    public async Task<IActionResult> Get([FromQuery] DateTime? inicio = null, [FromQuery] DateTime? fim = null, CancellationToken cancellationToken = default)
    {
        try
        {
            DateTime dataInicio = inicio.HasValue ? inicio.Value.Date : DateTime.Today.Date;
            DateTime dataFim = fim.HasValue ? fim.Value.Date : DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            
            return Ok(await _mediator.Send(new TelemetriaRequest(dataInicio, dataFim), cancellationToken));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Problem("Erro ao tentar executar o request.");
        }
    }
}