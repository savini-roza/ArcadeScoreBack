using System.ComponentModel.DataAnnotations;

namespace ArcadeScore.Model
{
    public class Jogador
    {
        [Key]
        public string NomeJogador { get; set;}
        public int PartidasJogadas { get; set; }
        public int MediaPontuacao { get; set; }
        public int MaiorPontuacao { get; set; }
        public int MenorPontuacao { get; set; }
        public int QtdRecordeBatido { get; set; }
        public TimeSpan TempoJogado { get; set; }
    }
}
