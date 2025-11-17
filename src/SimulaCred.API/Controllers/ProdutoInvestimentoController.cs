using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.Interfaces.Services;
using SimulaCred.Application.Services;
using SimulaCred.Domain.Entities;

namespace SimulaCred.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoInvestimentoController: ControllerBase
{
    private readonly IProdutoInvestimentoService _service;
    private readonly ILogger<ProdutoInvestimentoController> _logger;

    public ProdutoInvestimentoController(ILogger<ProdutoInvestimentoController> logger, IProdutoInvestimentoService service)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoInvestimento>>> ListarProdutos(CancellationToken cancellationToken)
    {
        return Ok(await _service.ListarProdutosAsync(cancellationToken));
    }
}