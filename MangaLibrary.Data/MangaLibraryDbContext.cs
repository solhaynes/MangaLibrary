using Microsoft.EntityFrameworkCore;

namespace MangaLibrary.Data.Entities;

public class MangaLibraryDbContext : DbContext
{
  public MangaLibraryDbContext(DbContextOptions<MangaLibraryDbContext> options) : base(options) { }

  public DbSet<Genre> Genres { get; set; } = null!;
  public DbSet<Author> Authors { get; set; } = null!;
  public DbSet<Series> Series { get; set; } = null!;
  public DbSet<Book> Books { get; set; } = null!;
}