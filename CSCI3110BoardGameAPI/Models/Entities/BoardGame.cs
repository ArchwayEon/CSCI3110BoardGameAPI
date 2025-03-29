using System.ComponentModel.DataAnnotations;

namespace CSCI3110BoardGameAPI.Models.Entities;

public class BoardGame
{
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    public int MaxPlayers { get; set; }

    public int MinPlayers { get; set; }

    public int PlayingTimeMinutes { get; set; }
}
