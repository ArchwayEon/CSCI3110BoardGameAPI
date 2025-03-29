using CSCI3110BoardGameAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI3110BoardGameAPI.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BoardGame> BoardGames => Set<BoardGame>();
}

