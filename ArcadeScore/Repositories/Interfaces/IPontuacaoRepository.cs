using ArcadeScore.Model;

namespace ArcadeScore.Repositories.Interfaces
{
    public interface IPontuacaoRepository
    {
        IList<Pontuacao> ObterRanking();
        IList<Pontuacao> ObterPontuacoesJogador(string nome);
        int ObterMediaJogador(string nome);
        int ObterMaiorJogador(string nome);
        int ObterMenorJogador(string nome);
        void Adicionar(Pontuacao pontuacao);
    }
}
