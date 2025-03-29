using Microsoft.EntityFrameworkCore;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Data
{
    public class GameDB : DbContext
    {
        public GameDB(DbContextOptions<GameDB> options) : base(options) { }

        // Define DbSet properties for each entity
        public DbSet<Game> Games { get; set; }
        public DbSet<GameRule> GameRules { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly set table names
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<GameRule>().ToTable("GameRule");
            modelBuilder.Entity<GameSession>().ToTable("GameSession");
            modelBuilder.Entity<Player>().ToTable("Player");

            // Configure relationships and constraints

            // Game -> GameRule (One-to-Many)
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Rules) // A game has many rules
                .WithOne(r => r.Game) // A rule belongs to one game
                .HasForeignKey(r => r.GameId) // Foreign key in GameRule
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete rules when a game is deleted

            // Player -> GameSession (One-to-Many)
            modelBuilder.Entity<Player>()
                .HasMany(p => p.GameSessions) // A player has many game sessions
                .WithOne(gs => gs.Player) // A game session belongs to one player
                .HasForeignKey(gs => gs.PlayerId) // Foreign key in GameSession
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete sessions when a player is deleted

            // Game -> GameSession (One-to-Many)
            modelBuilder.Entity<Game>()
                .HasMany(g => g.GameSessions) // A game has many game sessions
                .WithOne(gs => gs.Game) // A game session belongs to one game
                .HasForeignKey(gs => gs.GameId) // Foreign key in GameSession
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete sessions when a game is deleted

            // Ensure unique game names
            modelBuilder.Entity<Game>()
                .HasIndex(g => g.Name)
                .IsUnique();

            // Ensure unique player names
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Name)
                .IsUnique();

            // Configure precision for DateTime columns (if needed)
            modelBuilder.Entity<GameSession>()
                .Property(gs => gs.StartTime)
                .HasPrecision(3); // Milliseconds precision

            modelBuilder.Entity<GameSession>()
                .Property(gs => gs.EndTime)
                .HasPrecision(3); // Milliseconds precision

            // Seed data for Games (Range start can be negative)
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "FooBooLoo" },
                new Game {Id = 2, Name = "FizzBuzz" }
            );

            // Seed data for GameRules (for each game)
            modelBuilder.Entity<GameRule>().HasData(
                new GameRule { Id = 1, Divisor = 7, Replacement = "Foo" },
                new GameRule { Id = 2, Divisor = 13, Replacement = "Boo" },
                new GameRule { Id = 3, Divisor = 103, Replacement = "Loo" }

            );

            // Seed data for Players
            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Name = "Alice"},  
                new Player {Id = 2, Name = "Bob" }     
            );

            // Seed data for GameSession (Example attempts for users)
            modelBuilder.Entity<GameSession>().HasData(
                new GameSession { Id = 1, PlayerId = 1, GameId = 1, CorrectAnswers = 3, IncorrectAnswers = 1, Duration = 60 },
                new GameSession { Id = 2, PlayerId = 2, GameId = 2, CorrectAnswers = 2, IncorrectAnswers = 2, Duration = 45 }
            );
        }
    }
}