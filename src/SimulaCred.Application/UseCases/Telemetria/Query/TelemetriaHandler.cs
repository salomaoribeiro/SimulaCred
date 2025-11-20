using MediatR;
using SimulaCred.Application.Interfaces.Repositories;

namespace SimulaCred.Application.UseCases.Telemetria.Query;

public class TelemetriaHandler: IRequestHandler<TelemetriaRequest, TelemetriaResponse>
{
    private readonly ITelemetriaRepository _telemetriaRepository;

    public TelemetriaHandler(ITelemetriaRepository telemetriaRepository)
    {
        _telemetriaRepository = telemetriaRepository;
    }

    public async Task<TelemetriaResponse> Handle(TelemetriaRequest request, CancellationToken cancellationToken)
    {
        var telemetrias = await _telemetriaRepository.GetAllAsync(
            cancellationToken: cancellationToken,
            expression: t => t.CreatedAt >= request.DataInicio && t.CreatedAt <= request.DataFim);

        var servicos = telemetrias
            .GroupBy(t => t.Nome)
            .Select(g => new Servicos(
                Nome: g.Key,
                QuantidadeChamadas: g.Count(),
                MediaTempoRespostaMS: (long)g.Average(t => t.Tempo)
            ))
            .ToList();

        return new TelemetriaResponse(
            servicos: servicos,
            periodo: new Periodo(
                Inicio: request.DataInicio.ToString("yyyy-MM-dd"),
                Fim: request.DataFim.ToString("yyyy-MM-dd")
            )
        );
    }
}