using FizzBuzzDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzDatabase.Data
{
    public class GameDB: DbContext
    {
        public GameDB(DbContextOptions<GameDB> options ) : base(options) { }

        public DbSet<GameRule> GameRules { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Models.GameRule> GameRule { get; set; }
        public DbSet<Models.GameSession> GameSession { get; set; }
        public DbSet<Models.Player> Player { get; set; }
        public DbSet<Models.Game> Game { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                    {
                            Id = 1,
                            GameName = "Default Game", Author = "Admin", MinRange = 1, MaxRange = 100, Timer = 60
                    }
            );
            modelBuilder.Entity<GameRule>().HasData(
                new GameRule { Id = 1, Divisor = 7, Word = "Foo", GameId = 1 },
                new GameRule { Id = 2, Divisor = 13, Word = "Boo", GameId = 1 },
                new GameRule { Id = 3, Divisor = 103, Word = "Loo", GameId = 1 }
            );


            modelBuilder.Entity<Game>()
            .HasMany(g => g.Rules)
            .WithOne(r => r.Game)
            .HasForeignKey(r => r.GameId);

            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.Game)
                .WithMany()
                .HasForeignKey(gs => gs.GameId);

            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.Player)
                .WithMany()
                .HasForeignKey(gs => gs.PlayerId);
        }

    }
}
