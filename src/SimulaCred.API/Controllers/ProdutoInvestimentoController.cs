using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.UseCases.Produto.Query;
using SimulaCred.Application.UseCases.Telemetria.Command;
using SimulaCred.Domain.Entities;
using SimulaCred.Domain.Entities.Enums;

namespace SimulaCred.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoInvestimentoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProdutoInvestimentoController> _logger;

    public ProdutoInvestimentoController(ILogger<ProdutoInvestimentoController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("/listar-produtos")]
    public async Task<ActionResult<IEnumerable<ProdutoInvestimento>>> ListarProdutos(CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var retorno = await _mediator.Send(new ListarProdutosRequest(), cancellationToken);
            return Ok(retorno);

        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return Problem("Erro ao tentar listar os produtos.");
        }
        finally
        {
            sw.Stop();
            await _mediator.Send(new SalvarTelemetriaRequest("/listar-produtos",  sw.ElapsedMilliseconds), cancellationToken);
        }
    }
    
    [Authorize]
    [HttpGet("/produtos-recomendados/{perfil}")]
    public async Task<ActionResult<IEnumerable<ProdutosPorPerfilResponse>>> Simulacoes([FromRoute] PerfilInvestidor perfil, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return Ok(await _mediator.Send(new ProdutosPorPerfilRequest(perfil), cancellationToken));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return Problem("Erro ao tentar listar os produtos recomendados.");
        }
        finally
        {
            sw.Stop();
            await _mediator.Send(new SalvarTelemetriaRequest("/produtos-recomendados",  sw.ElapsedMilliseconds), cancellationToken);
        }
    } 
}
