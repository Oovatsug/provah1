using CascaApi.Models;

namespace CascaApi.Repositories;

public interface IJogadorRepository
{
    IEnumerable<Jogador> ObterTodos();
    Jogador? ObterPorCpf(string cpf);
    bool ExisteCpf(string cpf);
    void Adicionar(Jogador jogador);
}
