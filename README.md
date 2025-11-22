# SimulaCred

Breve descrição
--------------
SimulaCred é um projeto de exemplo para simulação de investimentos e recomendação de perfil de investidor. Implementa casos de uso para simular aplicações, obter histórico por cliente, gerar telemetria e recomendar produtos de investimento conforme o perfil do cliente. O objetivo é demonstrar uma arquitetura em camadas com princípios de Clean Architecture, padrões como CQRS/Mediator e boas práticas para testes automatizados.

Tecnologias utilizadas
----------------------
- C# / .NET (projeto criado utilizando .NET Core 8)
- MediatR (padrão Mediator para casos de uso/handlers)
- Repositório (interface-driven repository pattern)
- xUnit + Moq (testes unitários)
- Docker (empacotamento e execução em container)
- Entity Framework Core - ORM para persistência

Padrões e Princípios de Projeto
-------------------------------
- Clean Architecture : separação entre Domínio, Aplicação, Infraestrutura e API.
- CQRS (Command / Query Responsibility Segregation): comandos e queries tratados por Handlers via MediatR.
- Dependency Injection: injeção de repositórios, loggers e serviços nos handlers.
- Repository Pattern: abstração do acesso a dados por meio de interfaces.
- SOLID: organização do código seguindo os princípios de responsabilidade única, aberto/fechado, etc.
- Testes unitários: cobertura de handlers e regras de negócio isoladas através de mocks.
- Testes de integração com a biblioteca testcontainers

Estrutura de pastas (visão geral)
-------------------------------
A estrutura do repositório segue uma convenção por projetos dentro de `src/`:

- src/
  - SimulaCred.Api/                   -> API HTTP / controllers (expondo os endpoints)
  - SimulaCred.Application/           -> Casos de uso, DTOs, Handlers (MediatR), interfaces de repositório
  - SimulaCred.Domain/                -> Entidades, Value Objects, enums e regras de domínio
  - SimulaCred.Infrastructure/        -> Implementações de repositório, EF Core, persistência
  - SimulaCred.UnitTests/             -> Testes unitários (xUnit / Moq)
  - SimulaCred.IntegrationTests/      -> Testes de integração com testcontainers


Instruções de uso (local / desenvolvimento)
-------------------------------------------
Pré-requisitos:
- .NET SDK 8
- Docker (opcional)
- dotnet CLI: dotnet --version

1. Restaurar pacotes
   - dotnet restore

2. Build
   - dotnet build

3. Executar a aplicação
   - Navegue até a pasta do projeto da API (src/SimulaCred.API)
   - dotnet run

4. Executar testes
   - dotnet test src/SimulaCred.UnitTests (na pasta src)

Como executar no Docker
-----------------------
1. Rodar o projeto - dentro da pasta da solução (pasta src) execute o comando
  - docker-compose up -d --build

2. Acessar a applicação
  - http://localhost:8080/swagger/index.html

3. Usuário padrão
  - usuário: admin
  - senha: admin

4. Remover os containers
  - docker-compose down


Próximos passos
------------------------------
Mudar alguns métodos como o GetAllAsync porque ele usa função e parâmetros opcionais que atrapalharam a criação dos testes.
Acertar e aumentar a cobertura dos testes de integração porque eles pararam de funcionar após eu ter feito alguma coisa que não identifiquei. :(
