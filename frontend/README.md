# SPED Task Tracker — Frontend

Aplicação de gerenciamento de tarefas desenvolvida em **Angular 21** como parte do desafio técnico SPED.

---

## Pré-requisitos

- Node.js 20+
- Angular CLI 21+

```bash
npm install -g @angular/cli
```

---

## Instalação e execução

```bash
# Na pasta frontend
npm install
ng serve
```

Acesse: `http://localhost:4200`

> ⚠️ O backend precisa estar rodando em `http://localhost:5219` para a aplicação funcionar.

---

## Estrutura do projeto

```
src/app/
├── core/
│   ├── models/         # Interface Task, enum TaskStatus e DTOs
│   └── services/       # TaskService — toda comunicação com a API
├── features/
│   └── tasks/          # Componentes de task (board, card, modais)
├── layout/
│   └── main-layout/    # Layout principal: sidebar + área de conteúdo
└── shared/
    └── components/     # Header e Footer reutilizáveis
```

---

## Decisões técnicas

**Standalone Components (Angular 17+)**
Projeto utiliza a arquitetura moderna do Angular, sem `NgModule`. Cada componente declara suas próprias dependências via `imports: []`.

**TaskService com Injeção de Dependência**
Toda comunicação com a API está centralizada no `TaskService` (`providedIn: 'root'`). Os componentes nunca fazem chamadas HTTP diretamente — apenas consomem o serviço injetado via construtor.

**Enum `TaskStatus`**
O status das tarefas espelha exatamente o enum do backend (`Pending=0`, `InProgress=1`, `Completed=2`), evitando conversões manuais e garantindo consistência.

---

## Funcionalidades

| Ação | Como acessar |
|---|---|
| Visualizar tasks | Painel principal — 3 colunas (Kanban) |
| Criar task | Sidebar → "Criar Nova Task" |
| Editar task | Sidebar → "Editar Task" |
| Excluir task | Sidebar → "Excluir Task" (com confirmação) |
| Buscar task | Sidebar → "Procurar Task" (por UUID) |
| Status da API | Indicador no rodapé (verde/vermelho) |

---

## API utilizada

Base URL: `http://localhost:5219/api/v1/tasks`

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/findall` | Lista todas as tasks |
| `GET` | `/findby/:id` | Busca uma task por UUID |
| `POST` | `/new` | Cria uma nova task |
| `PUT` | `/update/:id` | Atualiza descrição e status |
| `DELETE` | `/delete/:id` | Remove uma task |
| `GET` | `/hc` | Health check da API |

---

## Histórico de commits

O projeto foi construído com commits atômicos, refletindo cada etapa do desenvolvimento:

---

## Autor

**Elias A. Néri** — [github.com/eliasneri](https://github.com/eliasneri)
