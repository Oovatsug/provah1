# API de Cadastro — Time de Futebol de Araxá

API REST desenvolvida em .NET 10 para cadastro e gerenciamento de jogadores do time de futebol de Araxá.

---

## 📁 Estrutura do Projeto

- **`Models/`**
  - [`Jogador.cs`](Models/Jogador.cs): Modelo do jogador com todas as validações de dados via DataAnnotations.
- **`Repositories/`**
  - [`IJogadorRepository.cs`](Repositories/IJogadorRepository.cs): Interface com operações de persistência e validação de existência por CPF.
  - [`JogadorRepository.cs`](Repositories/JogadorRepository.cs): Implementação em memória (`Singleton`), mantendo os jogadores cadastrados durante a execução.
- **`Controllers/`**
  - [`JogadoresController.cs`](Controllers/JogadoresController.cs): Endpoints REST (`POST`, `GET`).
- **`Program.cs`**
  - Configuração da injeção de dependência e inicialização da API.

---

## 📋 Regras de Negócio e Validações

| Campo | Validação | Descrição |
|---|---|---|
| **`nome`** | Obrigatório, 3 a 50 caracteres | Nome completo ou apelido do jogador. |
| **`cpf`** | Obrigatório, exatamente 11 dígitos | CPF sem máscara com 11 números. |
| **`descricao`** | Opcional, máximo 500 caracteres | Informações adicionais / histórico do jogador. |
| **`posicao`** | Obrigatório, posições aceitas | `gl`, `za`, `ld`, `le`, `vo`, `md`, `at`. |

### Regra de Unicidade de CPF
- **Não pode existir mais de um jogador cadastrado com o mesmo CPF.**
- Caso o CPF já esteja cadastrado, a API recusa o cadastro retornando status HTTP **`409 Conflict`** e a mensagem de erro:
  `"Já existe um jogador cadastrado com o CPF {cpf}."`

### Posições Permitidas
- `gl` — Goleiro
- `za` — Zagueiro
- `ld` — Lateral Direito
- `le` — Lateral Esquerdo
- `vo` — Volante
- `md` — Meio-Campo / Meia
- `at` — Atacante

---

## 🚀 Endpoints

### 1. Cadastrar Jogador
- **Rota:** `POST /jogadores` (ou `POST /jogador`)
- **Corpo da Requisição (JSON):**
```json
{
  "nome": "Carlos Araxá",
  "cpf": "12345678901",
  "descricao": "Atacante veloz formado nas categorias de base do Ganso.",
  "posicao": "at"
}
```
- **Respostas:**
  - `201 Created`: Jogador cadastrado com sucesso.
  - `400 Bad Request`: Dados inválidos (nome menor que 3 ou maior que 50 chars, CPF diferente de 11 dígitos, posição inválida ou descrição > 500 chars).
  - `409 Conflict`: CPF já cadastrado no sistema.

### 2. Listar Todos os Jogadores
- **Rota:** `GET /jogadores`
- **Resposta:**
  - `200 OK`: Lista com todos os jogadores cadastrados.

### 3. Consultar Jogador por CPF
- **Rota:** `GET /jogadores/{cpf}`
- **Respostas:**
  - `200 OK`: Dados do jogador encontrado.
  - `404 Not Found`: Mensagem informando que o jogador não foi encontrado.

---

## 💻 Como Executar

No terminal, dentro da pasta `CascaApi`:

```powershell
dotnet run
```
