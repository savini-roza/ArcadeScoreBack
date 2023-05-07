using System.ComponentModel.DataAnnotations;

namespace ArcadeScore.Model
{
    public class Pontuacao
    {
        [Key]
        public int PontuacaoId { get; set;}
        public DateTime DataPartida { get; set; }
        public int PontuacaoTotal { get; set; }
        public string NomeJogador { get; set; }
    }
}
