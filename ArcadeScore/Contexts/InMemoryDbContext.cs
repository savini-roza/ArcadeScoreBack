using ArcadeScore.Model;
using Microsoft.EntityFrameworkCore;

namespace ArcadeScore.Contexts
{
    public class InMemoryDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ArcadeDb");
        }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Pontuacao> Pontuacoes { get; set; }
    }
}
