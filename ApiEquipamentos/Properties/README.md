# API de Equipamentos

## Tema

Esta API permite gerenciar equipamentos patrimoniais.

## Tecnologias utilizadas

- C#
- ASP.NET Core Minimal API
- Entity Framework Core
- SQLite

## Como executar

```bash
cd ApiEquipamentos
dotnet run
```

## Endpoints

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | `/` | Mensagem inicial |
| GET | `/status` | Status da API |
| GET | `/equipamentos` | Lista todos os equipamentos |
| GET | `/equipamentos/{id}` | Busca um equipamento por ID |
| POST | `/equipamentos` | Cadastra um equipamento |
| PUT | `/equipamentos/{id}` | Atualiza um equipamento |
| DELETE | `/equipamentos/{id}` | Remove um equipamento |

## Exemplo de JSON

```json
{
  "nome": "Notebook Dell",
  "tipo": "Informática",
  "valorPatrimonio": 3500.00,
  "ativo": true,
  "dataCadastro": "2026-05-19T10:00:00"
}
```

## Vídeo explicativo

Link do vídeo: 