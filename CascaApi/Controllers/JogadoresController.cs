using CascaApi.Models;
using CascaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CascaApi.Controllers;

[ApiController]
[Route("[controller]")]
[Route("jogador")]
public class JogadoresController : ControllerBase
{
    private readonly IJogadorRepository _repository;

    public JogadoresController(IJogadorRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Cadastrar(Jogador jogador)
    {
        if (_repository.ExisteCpf(jogador.Cpf))
        {
            return Conflict($"Já existe um jogador cadastrado com o CPF {jogador.Cpf}.");
        }

        _repository.Adicionar(jogador);
        return CreatedAtAction(nameof(ObterPorCpf), new { cpf = jogador.Cpf }, jogador);
    }

    [HttpGet]
    public IActionResult ObterTodos()
    {
        return Ok(_repository.ObterTodos());
    }

    [HttpGet("{cpf}")]
    public IActionResult ObterPorCpf(string cpf)
    {
        var jogador = _repository.ObterPorCpf(cpf);

        if (jogador is null)
        {
            return NotFound($"Jogador com CPF {cpf} não encontrado.");
        }

        return Ok(jogador);
    }
}
