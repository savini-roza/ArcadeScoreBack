using ArcadeScore.Model;

namespace ArcadeScore.Repositories.Interfaces
{
    public interface IJogadorRepository
    {
        Jogador Obter(string nome);

        void Adicionar(Jogador jogador);
    }
}
