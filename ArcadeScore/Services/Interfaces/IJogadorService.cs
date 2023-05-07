using ArcadeScore.Model;

namespace ArcadeScore.Services.Interfaces
{
    public interface IJogadorService
    {
        Jogador ObterJogador(string nome);
    }
}
