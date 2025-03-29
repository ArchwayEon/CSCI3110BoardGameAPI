using CSCI3110BoardGameAPI.Models.Entities;

namespace CSCI3110BoardGameAPI.Services;

public class BoardGameInitializer
{
    private readonly ApplicationDbContext _db;

    public BoardGameInitializer(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task SeedBoardGamesAsync()
    {
        // Ensure database is created
        _db.Database.EnsureCreated();

        // Check if any board games exist - if so, don't seed
        if (_db.BoardGames.Any())
        {
            return;
        }

        var boardGames = new List<BoardGame>
            {
                new BoardGame
                {
                    Title = "Kingdoms of Valor",
                    MinPlayers = 2,
                    MaxPlayers = 5,
                    PlayingTimeMinutes = 90
                },
                new BoardGame
                {
                    Title = "Cosmic Explorers",
                    MinPlayers = 3,
                    MaxPlayers = 6,
                    PlayingTimeMinutes = 120
                },
                new BoardGame
                {
                    Title = "Merchant Guild",
                    MinPlayers = 2,
                    MaxPlayers = 4,
                    PlayingTimeMinutes = 60
                },
                new BoardGame
                {
                    Title = "Dungeon Delvers",
                    MinPlayers = 1,
                    MaxPlayers = 5,
                    PlayingTimeMinutes = 180
                },
                new BoardGame
                {
                    Title = "Railway Empire",
                    MinPlayers = 2,
                    MaxPlayers = 4,
                    PlayingTimeMinutes = 120
                },
                new BoardGame
                {
                    Title = "Botanical Gardens",
                    MinPlayers = 1,
                    MaxPlayers = 4,
                    PlayingTimeMinutes = 45
                },
                new BoardGame
                {
                    Title = "Pirate's Cove",
                    MinPlayers = 3,
                    MaxPlayers = 6,
                    PlayingTimeMinutes = 75
                },
                new BoardGame
                {
                    Title = "Mystery Mansion",
                    MinPlayers = 2,
                    MaxPlayers = 8,
                    PlayingTimeMinutes = 60
                },
                new BoardGame
                {
                    Title = "Quantum Physics",
                    MinPlayers = 2,
                    MaxPlayers = 4,
                    PlayingTimeMinutes = 150
                },
                new BoardGame
                {
                    Title = "Festival of Fools",
                    MinPlayers = 4,
                    MaxPlayers = 10,
                    PlayingTimeMinutes = 30
                }
            };

        await _db.BoardGames.AddRangeAsync(boardGames);
        await _db.SaveChangesAsync();
    }
}
