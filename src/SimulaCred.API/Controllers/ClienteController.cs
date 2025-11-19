using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimulaCred.Application.UseCases.Simulacao.Query;

namespace SimulaCred.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProdutoInvestimentoController> _logger;


    public ClienteController(IMediator mediator, ILogger<ProdutoInvestimentoController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpGet("/investimentos/{clienteId}")]
    public async Task<IEnumerable<InvestimentosPorClienteResponse>> Simulacoes([FromRoute] int clienteId, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new InvestimentosPorClienteRequest(clienteId), cancellationToken);
    } 
}