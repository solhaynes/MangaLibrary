using MangaLibrary.Data;
using MangaLibrary.Models.Genre;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;

namespace MangaLibrary.Services.Genre;

public class GenreService : IGenreService
{
  private MangaLibraryDbContext _context;
  public GenreService(MangaLibraryDbContext context)
  {
    _context = context; 
  }

  public async Task<bool> CreateGenreAsync(GenreCreate model)
  {
    MangaLibrary.Data.Genre entity = new()
    {
      Name = model.Name,
      Description = model.Description
    };
    _context.Genres.Add(entity);
    return await _context.SaveChangesAsync() == 1;

  }

  public async Task<List<GenreListItem>> GetAllGenresAsync()
  {
    List<GenreListItem> genres = await _context.Genres
      .Select(r => new GenreListItem()
      {
        Id = r.Id,
        Name = r.Name,
        Description = r.Description
      })
      .ToListAsync();

      return genres;
  }

