# 🔧 API de Equipamentos

Uma API REST simples e funcional para gerenciar equipamentos patrimoniais, desenvolvida com ASP.NET Core Minimal API, Entity Framework Core e SQLite.

## 🛠️ Tecnologias utilizadas

- C#
- ASP.NET Core Minimal API
- Entity Framework Core
- SQLite

## 📦 Como executar

Clone o repositório e entre na pasta do projeto:

```bash
cd ApiEquipamentos
dotnet run
```

A API estará disponível em `http://localhost:5170`.

## 🗂️ Estrutura do projeto

```
ApiEquipamentos/
├── Program.cs          # Configuração da aplicação e endpoints
├── Equipamento.cs      # Entidade principal
├── AppDbContext.cs     # Contexto do banco de dados
├── ApiEquipamentos.csproj
├── appsettings.json
└── equipamentos.db     # Banco SQLite criado automaticamente
```

## 📋 Entidade principal

A entidade `Equipamento` representa um equipamento patrimonial e possui as seguintes propriedades:

| Propriedade | Tipo | Descrição |
| --- | --- | --- |
| `Id` | int | Identificador único |
| `Nome` | string | Nome do equipamento |
| `Tipo` | string | Categoria do equipamento |
| `ValorPatrimonio` | decimal | Valor patrimonial |
| `Ativo` | bool | Se o equipamento está em uso |
| `DataCadastro` | DateTime | Data de registro |

## 🚀 Endpoints

### Gerais

| Método | Rota | Descrição | Retorno |
| --- | --- | --- | --- |
| GET | `/` | Mensagem inicial da API | 200 OK |
| GET | `/status` | Status da API com data e hora | 200 OK |

### Equipamentos

| Método | Rota | Descrição | Retorno |
| --- | --- | --- | --- |
| GET | `/equipamentos` | Lista todos os equipamentos | 200 OK |
| GET | `/equipamentos/{id}` | Busca um equipamento por ID | 200 OK / 404 Not Found |
| GET | `/equipamentos/ativos` | Lista apenas equipamentos ativos | 200 OK |
| GET | `/equipamentos/count` | Retorna o total de equipamentos cadastrados | 200 OK |
| POST | `/equipamentos` | Cadastra um novo equipamento | 201 Created |
| POST | `/equipamentos/validado` | Cadastra com validação dos campos | 201 Created / 400 Bad Request |
| PUT | `/equipamentos/{id}` | Atualiza um equipamento existente | 200 OK / 404 Not Found |
| DELETE | `/equipamentos/{id}` | Remove um equipamento | 204 No Content / 404 Not Found |

## 📝 Exemplos de JSON

### Cadastrar um equipamento

```json
{
  "nome": "Notebook Dell",
  "tipo": "Informática",
  "valorPatrimonio": 3500.00,
  "ativo": true,
  "dataCadastro": "2026-05-19T10:00:00"
}
```

### Atualizar um equipamento

```json
{
  "nome": "Notebook Dell Atualizado",
  "tipo": "Informática",
  "valorPatrimonio": 4000.00,
  "ativo": true,
  "dataCadastro": "2026-05-19T10:00:00"
}
```

### Resposta do /status

```json
{
  "status": "online",
  "mensagem": "API funcionando",
  "dataHora": "2026-05-19T10:00:00"
}
```

### Resposta do /equipamentos/count

```json
{
  "total": 3
}
```

## ✅ Validações

A rota `/equipamentos/validado` aplica as seguintes validações antes de salvar:

- Nome não pode ser vazio → retorna `400 Bad Request`
- Tipo não pode ser vazio → retorna `400 Bad Request`
- Valor patrimonial deve ser maior que zero → retorna `400 Bad Request`

## 🎬 Vídeo explicativo

Link do vídeo: [Assista ao vídeo no YouTube](https://www.youtube.com/watch?v=Iw5lTH2VqLM)

---

Desenvolvido por Lucas Roldão Cardoso — Universidade Luterana do Brasil
