# SPED Task Tracker

Projeto desenvolvido como parte do desafio técnico do processo seletivo SPED.

---

## Sobre o desafio

O objetivo foi construir uma aplicação web fullstack simples para gerenciamento de tarefas internas, simulando um cenário real do dia a dia de um time.

O foco:

- Qualidade da arquitetura e organização do código
- Entendimento de Injeção de Dependência (backend e frontend)
- Disciplina no versionamento com commits atômicos
- Capacidade de entregar uma solução funcional de ponta a ponta

---

## Estrutura do repositório

```
sped-task-tracker/
├── backend/    # API REST em .NET 8 (C#)
└── frontend/   # Interface web em Angular 21
```

---

## Documentação por projeto

Cada projeto possui seu próprio README com instruções detalhadas de instalação, arquitetura e decisões técnicas:

- 📄 [Documentação do Backend](https://github.com/eliasneri/sped-task-tracker/tree/main/backend/README.md) — .NET 8, EF Core, Swagger, Docker
- 📄 [Documentação do Frontend](https://github.com/eliasneri/sped-task-tracker/tree/main/frontend/README.md) — Angular 21, Standalone Components, TaskService

---

## Executando com Docker Compose

Com o Docker instalado, basta um único comando na raiz do repositório:

```bash
docker compose up --build
```

| Serviço | Endereço |
|---|---|
| Frontend | http://localhost:4200 |
| Backend / Swagger | http://localhost:8080/swagger |

Para encerrar:

```bash
docker compose down
```

---

## Tecnologias utilizadas

| Camada | Tecnologia |
|---|---|
| Backend | .NET 8, ASP.NET Core, EF Core, Swagger |
| Frontend | Angular 21, TypeScript |
| Infraestrutura | Docker, Docker Compose |

---

## Bases de conhecimento utilizadas

Este projeto foi desenvolvido com apoio das seguintes fontes:

| Fonte | Tipo |
|---|---|
| [Documentação oficial do Angular](https://angular.dev/docs) | Documentação |
| [Canal Giaretta](https://www.youtube.com/@giarettaio) | Vídeos / YouTube |
| [Stack Overflow](https://stackoverflow.com) | Comunidade / Q&A |
| Claude (Anthropic) | Assistente de IA |
| ChatGPT (OpenAI) | Assistente de IA |
| Gemini (Google) | Assistente de IA |

---

## Autor

**Elias A. Néri** — [github.com/eliasneri](https://github.com/eliasneri)
