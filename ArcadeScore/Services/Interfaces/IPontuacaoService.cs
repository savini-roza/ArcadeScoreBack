using ArcadeScore.Model;

namespace ArcadeScore.Services.Interfaces
{
    public interface IPontuacaoService
    {
        IList<Pontuacao> ObterRanking();


        void Adicionar(Pontuacao pontuacao);


    }
}
