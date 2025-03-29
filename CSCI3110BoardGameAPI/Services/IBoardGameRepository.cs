using CSCI3110BoardGameAPI.Models.Entities;

namespace CSCI3110BoardGameAPI.Services;

public interface IBoardGameRepository
{
    Task<ICollection<BoardGame>> ReadAll();
    Task<BoardGame> Create(BoardGame boardGame);
    Task<BoardGame?> Read(int id);
    Task Update(int oldId, BoardGame updatedBoardGame);
    Task Delete(int id);
}

