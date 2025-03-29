using CSCI3110BoardGameAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI3110BoardGameAPI.Services;

public class DbBoardGameRepository : IBoardGameRepository
{
    private readonly ApplicationDbContext _db;

    public DbBoardGameRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<BoardGame>> ReadAll()
    {
        return await _db.BoardGames.ToListAsync();
    }

    public async Task<BoardGame> Create(BoardGame boardGame)
    {
        await _db.BoardGames.AddAsync(boardGame);
        await _db.SaveChangesAsync();
        return boardGame;
    }

    public async Task<BoardGame?> Read(int id)
    {
        return await _db.BoardGames.FindAsync(id);
    }

    public async Task Update(int oldId, BoardGame updatedBoardGame)
    {
        var boardGameToUpdate = await Read(oldId);
        if (boardGameToUpdate != null)
        {
            boardGameToUpdate.Title = updatedBoardGame.Title;
            boardGameToUpdate.MinPlayers = updatedBoardGame.MinPlayers;
            boardGameToUpdate.MaxPlayers = updatedBoardGame.MaxPlayers;
            boardGameToUpdate.PlayingTimeMinutes = updatedBoardGame.PlayingTimeMinutes;

            await _db.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var boardGameToDelete = await Read(id);
        if (boardGameToDelete != null)
        {
            _db.BoardGames.Remove(boardGameToDelete);
            await _db.SaveChangesAsync();
        }
    }
}