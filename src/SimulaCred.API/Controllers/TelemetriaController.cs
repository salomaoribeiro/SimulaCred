using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.UseCases.Telemetria.Command;

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
        // var r = await _mediator.Send(new SalvarTelemetriaRequest(cancellationToken, ));
        return Ok();
    }
}