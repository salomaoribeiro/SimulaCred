using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.UseCases.Perfil;
using SimulaCred.Application.UseCases.Telemetria.Command;

namespace SimulaCred.API.Controllers;

[ApiController]
public class PerfilRiscoController : ControllerBase
{
    private readonly ILogger<PerfilRiscoController> _logger;
    private readonly IMediator _mediator;
    
    public PerfilRiscoController(ILogger<PerfilRiscoController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("/perfil-risco/{clienteId}")]
    public async Task<IActionResult> GetPerfil(int clienteId, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return Ok(await _mediator.Send(new PerfilRiscoRequest(clienteId), cancellationToken));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Problem("Erro ao tentar executar a requisição.");
        }
        finally
        {
            sw.Stop();
            await _mediator.Send(new SalvarTelemetriaRequest("/perfil-risco/",  sw.ElapsedMilliseconds), cancellationToken);
        }
    }
}