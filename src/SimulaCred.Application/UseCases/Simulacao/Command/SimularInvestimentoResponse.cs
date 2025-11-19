namespace SimulaCred.Application.UseCases.Simulacao.Command;

public sealed record SimularInvestimentoResponse(ProdutoValidado produtoValidado, ResultadoSimulacao resultadoSimulacao, DateTime DataSimulacao);

public sealed record ProdutoValidado(
  int id,
  string nome,
  string tipo,
  decimal rentabilidade,
  string risco
);

public sealed record ResultadoSimulacao(
  decimal valorFinal,
  decimal rentabilidadeEfetiva,
  int prazoMeses
);
