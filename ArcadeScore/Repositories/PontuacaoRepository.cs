using ArcadeScore.Contexts;
using ArcadeScore.Model;
using ArcadeScore.Repositories.Interfaces;

namespace ArcadeScore.Repositories
{
    public class PontuacaoRepository : IPontuacaoRepository
    {
        private readonly InMemoryDbContext _inMemoryDbContext;

        public PontuacaoRepository(InMemoryDbContext inMemoryDbContext)
        {
            _inMemoryDbContext = inMemoryDbContext;
        }

        public IList<Pontuacao> ObterRanking()
        {
            return _inMemoryDbContext.Pontuacoes.OrderByDescending(e => e.PontuacaoTotal).Take(10).ToList();
        }

        public IList<Pontuacao> ObterPontuacoesJogador(string nome)
        {
            return _inMemoryDbContext.Pontuacoes.Where(e => e.NomeJogador == nome).ToList();
        }

        public int ObterMediaJogador(string nome)
        {
            return (int)ObterPontuacoesJogador(nome).Average(e => e.PontuacaoTotal);
        }

        public int ObterMaiorJogador(string nome)
        {
            return (int)ObterPontuacoesJogador(nome).Max(e => e.PontuacaoTotal);
        }

        public int ObterMenorJogador(string nome)
        {
            return (int)ObterPontuacoesJogador(nome).Min(e => e.PontuacaoTotal);
        }

        public void Adicionar(Pontuacao pontuacao)
        {
            _inMemoryDbContext.Pontuacoes.Add(pontuacao);
            _inMemoryDbContext.SaveChanges();
        }
    }
}
