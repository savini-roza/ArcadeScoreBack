using ArcadeScore.Model;
using ArcadeScore.Repositories.Interfaces;
using ArcadeScore.Services.Interfaces;

namespace ArcadeScore.Services
{
    public class JogadorService : IJogadorService
    {
        private readonly IPontuacaoRepository _pontuacaoRepository;
        private readonly IJogadorRepository _jogadorRepository;

        public JogadorService(IPontuacaoRepository pontuacaoRepository, IJogadorRepository jogadorRepository)
        {
            _pontuacaoRepository = pontuacaoRepository;
            _jogadorRepository = jogadorRepository;
        }

        public Jogador ObterJogador(string nome)
        {
            var jogador = new Jogador()
            {
                NomeJogador = nome,
                MediaPontuacao = ObterMediaPontuacaoJogador(nome),
                MaiorPontuacao = ObterMaiorPontuacaoJogador(nome),
                MenorPontuacao = ObterMenorPontuacaoJogador(nome),
                PartidasJogadas = ObterPontuacoesJogador(nome).Count(),
                QtdRecordeBatido = ObterVezesRecordeBatido(nome),
                TempoJogado = ObterTempoJogado(nome)
            };

            return jogador;
        }

        private IList<Pontuacao> ObterPontuacoesJogador(string nome)
        {
            return _pontuacaoRepository.ObterPontuacoesJogador(nome);
        }

        private int ObterMediaPontuacaoJogador(string nome)
        {
            return _pontuacaoRepository.ObterMediaJogador(nome);
        }

        private int ObterMaiorPontuacaoJogador(string nome)
        {
            return _pontuacaoRepository.ObterMaiorJogador(nome);
        }

        private int ObterMenorPontuacaoJogador(string nome)
        {
            return _pontuacaoRepository.ObterMenorJogador(nome);
        }

        private int ObterVezesRecordeBatido(string nome)
        {
            var pontuacoes = ObterPontuacoesJogador(nome);
            int maiorAtual = pontuacoes.ElementAt(0).PontuacaoTotal;
            int vezes = 0;

            foreach (var p in pontuacoes)
            {
                if(p.PontuacaoTotal > maiorAtual)
                {
                    maiorAtual = p.PontuacaoTotal;
                    vezes++;
                }
            }

            return vezes;
        }

        private TimeSpan ObterTempoJogado(string nome)
        {
            var pontuacoes = ObterPontuacoesJogador(nome);
            if (pontuacoes.Count == 1)
            {
                return DateTime.Now - pontuacoes[0].DataPartida;
            }
            else
            {
                return pontuacoes.Max(e => e.DataPartida) - pontuacoes.Min(e => e.DataPartida);
            }
        }
    }
}
