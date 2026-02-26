# Sped Task Tracker API

API REST desenvolvida em **.NET 8** para gerenciamento de tarefas,
seguindo boas práticas de arquitetura e organização em camadas.

------------------------------------------------------------------------

## 🚀 Tecnologias Utilizadas

-   .NET 8
-   ASP.NET Core Web API
-   Entity Framework Core
-   Swagger / OpenAPI
-   Docker
-   CORS configurado para frontend separado

------------------------------------------------------------------------

## 📦 Arquitetura

O projeto segue separação clara de responsabilidades:

-   **Controllers** → Camada de entrada (HTTP)
-   **Services** → Regras de negócio
-   **Domain / Entities** → Entidades e validações
-   **Infrastructure** → Persistência com EF Core

------------------------------------------------------------------------

## 🗄️ Entity Framework Core

O projeto utiliza **Entity Framework Core** para persistência de dados.

Principais pontos:

-   Mapeamento via DbContext
-   Controle de estado das entidades
-   Persistência assíncrona
-   Regras de negócio protegidas no domínio (ex: tarefas em andamento
    não podem ser alteradas ou excluídas)

Exemplo de regra de negócio aplicada na entidade:

-   Tarefas com status **InProgress** não podem ser modificadas nem
    removidas.

Isso garante integridade mesmo que a validação não passe pela camada de
serviço.

------------------------------------------------------------------------

## 📘 Documentação Swagger

A API possui documentação automática via **Swagger (OpenAPI)**.

Ao executar o projeto, acesse:

    /swagger

A documentação permite:

-   Testar endpoints diretamente no navegador
-   Visualizar modelos de entrada e saída
-   Conferir códigos de status retornados
-   Validar contratos da API

------------------------------------------------------------------------

## 🌐 CORS

CORS configurado para permitir integração com frontend separado (ex:
React, Vue, Angular).

A política pode ser ajustada por ambiente (Development / Production).

------------------------------------------------------------------------

## 🐳 Docker

O projeto possui Dockerfile com:

-   Build multi-stage
-   Publicação otimizada
-   Exposição na porta 8080

Build:

    docker build -t sped-task-tracker .

Run:

    docker run -p 8080:8080 sped-task-tracker

------------------------------------------------------------------------

## 🔐 Regras de Negócio Importantes

-   Tarefas com status `InProgress` não podem ser:
    -   Alteradas
    -   Excluídas
-   Uso correto de códigos HTTP:
    -   201 Created
    -   204 NoContent
    -   400 BadRequest
    -   404 NotFound

------------------------------------------------------------------------

## ✅ Pontos Avaliativos

✔ Separação em camadas\
✔ Uso adequado de EF Core\
✔ Regras de negócio protegidas no domínio\
✔ Documentação Swagger configurada\
✔ CORS configurado corretamente\
✔ Dockerização pronta para deploy

------------------------------------------------------------------------

Projeto desenvolvido com foco em organização, boas práticas e clareza
arquitetural.
