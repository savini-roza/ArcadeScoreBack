using ArcadeScore.Contexts;
using ArcadeScore.Model;
using ArcadeScore.Repositories.Interfaces;

namespace ArcadeScore.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly InMemoryDbContext _inMemoryDbContext;

        public JogadorRepository(InMemoryDbContext inMemoryDbContext)
        {
            _inMemoryDbContext = inMemoryDbContext;
        }

        public Jogador Obter(string nome)
        {
            return _inMemoryDbContext.Jogadores.SingleOrDefault(e => e.NomeJogador == nome);
        }

        public void Adicionar(Jogador jogador)
        {
            _inMemoryDbContext.Jogadores.Add(jogador);
            _inMemoryDbContext.SaveChanges();
        }
    }
}
