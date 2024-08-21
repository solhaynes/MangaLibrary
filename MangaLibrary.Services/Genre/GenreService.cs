using MangaLibrary.Data.Entities;
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
    MangaLibrary.Data.Entities.Genre entity = new()
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

  public async Task<GenreDetail?> GetGenreDetailAsync(int id)
  {
    MangaLibrary.Data.Entities.Genre? genre = await _context.Genres
      .FirstOrDefaultAsync(r => r.Id == id);

    return genre is null ? null : new()
    {
      Id = genre.Id,
      Name = genre.Name,
      Description = genre.Description
    };
  }

  public async Task<bool> UpdateGenreAsync(GenreEdit model)
  {
    MangaLibrary.Data.Entities.Genre? entity = await _context.Genres.FindAsync(model.Id);

    if (entity is null)
    {
      return false;
    }

    entity.Name = model.Name;
    entity.Description = model.Description;
    return await _context.SaveChangesAsync() == 1;
  }

  public async Task<bool> DeleteGenreAsync(int id)
  {
    MangaLibrary.Data.Entities.Genre? entity = await _context.Genres.FindAsync(id);
    if (entity is null)
    {
      return false;
    }

    _context.Genres.Remove(entity);
    return await _context.SaveChangesAsync() == 1;
  }

  public async Task<List<GenreList>> GetGenreSelectListAsync()
  {
    {
        return _context.Genres
            .Select(x => new GenreList()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
    }
  }
}