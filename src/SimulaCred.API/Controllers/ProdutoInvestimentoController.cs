using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.UseCases.Produto.Query;
using SimulaCred.Domain.Entities;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoInvestimento>>> ListarProdutos(CancellationToken cancellationToken)
    {
        var retorno = await _mediator.Send(new ListarProdutosRequest(), cancellationToken);
        return Ok(retorno);
    }
    
    [HttpGet("/produtos-recomendados/{perfil}")]
    public async Task<IEnumerable<ProdutosPorPerfilResponse>> Simulacoes([FromRoute] string perfil, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new ProdutosPorPerfilRequest(perfil), cancellationToken);
    } 
}
