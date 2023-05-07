using ArcadeScore.Model;
using ArcadeScore.Repositories.Interfaces;
using ArcadeScore.Services.Interfaces;

namespace ArcadeScore.Services
{
    public class PontuacaoService : IPontuacaoService
    {
        private readonly IPontuacaoRepository _pontuacaoRepository;
        private readonly IJogadorRepository _jogadorRepository;

        public PontuacaoService(IPontuacaoRepository pontuacaoRepository, IJogadorRepository jogadorRepository)
        {
            _pontuacaoRepository = pontuacaoRepository;
            _jogadorRepository = jogadorRepository;
        }
        public IList<Pontuacao> ObterRanking()
        {
            return _pontuacaoRepository.ObterRanking();
        }

        public void Adicionar(Pontuacao pontuacao)
        {
            if (_jogadorRepository.Obter(pontuacao.NomeJogador) == null)
            {
                _jogadorRepository.Adicionar(new Jogador() { NomeJogador = pontuacao.NomeJogador });
            }

           _pontuacaoRepository.Adicionar(pontuacao);
        }
    }
}
