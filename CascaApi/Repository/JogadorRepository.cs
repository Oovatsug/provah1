using System.Text.RegularExpressions;
using CascaApi.Models;

namespace CascaApi.Repositories;

public class JogadorRepository : IJogadorRepository
{
    private readonly List<Jogador> _jogadores = [];

    public IEnumerable<Jogador> ObterTodos()
    {
        return _jogadores;
    }

    public Jogador? ObterPorCpf(string cpf)
    {
        var cpfLimpo = LimparCpf(cpf);
        return _jogadores.FirstOrDefault(j => LimparCpf(j.Cpf) == cpfLimpo);
    }

    public bool ExisteCpf(string cpf)
    {
        var cpfLimpo = LimparCpf(cpf);
        return _jogadores.Any(j => LimparCpf(j.Cpf) == cpfLimpo);
    }

    public void Adicionar(Jogador jogador)
    {
        _jogadores.Add(jogador);
    }

    private static string LimparCpf(string? cpf) =>
        Regex.Replace(cpf ?? string.Empty, @"\D", "");
}
