using CSCI3110BoardGameAPI.Models.Entities;
using CSCI3110BoardGameAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSCI3110BoardGameAPI.Controllers;

[EnableCors]
[Route("api/[controller]")]
[ApiController]
public class BoardGameController : ControllerBase
{
    private readonly IBoardGameRepository _boardGameRepo;

    public BoardGameController(IBoardGameRepository boardGameRepo)
    {
        _boardGameRepo = boardGameRepo;
    }

    // GET: api/boardgame/all
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var boardGames = await _boardGameRepo.ReadAll();
        return Ok(boardGames);
    }

    // GET: api/boardgame/one/{id}
    [HttpGet("one/{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var boardGame = await _boardGameRepo.Read(id);

        if (boardGame == null)
        {
            return NotFound();
        }

        return Ok(boardGame);
    }

    // POST: api/boardgame/create
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] BoardGame boardGame)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdBoardGame = await _boardGameRepo.Create(boardGame);
        return CreatedAtAction(nameof(GetOne), new { id = createdBoardGame.Id }, createdBoardGame);
    }

    // PUT: api/boardgame/update
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromForm] BoardGame boardGame)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _boardGameRepo.Update(boardGame.Id, boardGame);
        return NoContent();
    }

    // DELETE: api/boardgame/delete/{id}
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _boardGameRepo.Delete(id);
        return NoContent();
    }
}
