using MangaLibrary.Data.Entities;
using MangaLibrary.Models.Series;
using MangaLibrary.Services.Series;
using Microsoft.EntityFrameworkCore;

namespace MangaLibrary.Services.Series;

public class SeriesService : ISeriesService
{
  private MangaLibraryDbContext _context;
  public SeriesService(MangaLibraryDbContext context)
  {
    _context = context;
  }

  public async Task<bool> CreateSeriesAsync(SeriesCreate model)
  {
    MangaLibrary.Data.Entities.Series entity = new()
    {
      Title = model.Title,
      AuthorId = model.AuthorId,
      GenreId = model.GenreId,
      Description = model.Description,
      ImageLink = model.ImageLink
    };
    _context.Series.Add(entity);
    return await _context.SaveChangesAsync() == 1;

  }

  public async Task<List<SeriesListItem>> GetAllSeriesAsync()
  {
    List<SeriesListItem> series = await _context.Series
      .Select(r => new SeriesListItem()
      {
        Id = r.Id,
        Title = r.Title,
        ImageLink = r.ImageLink
      })
      .ToListAsync();

    return series;
  }

  // public async Task<SeriesDetail?> GetSeriesDetailAsync(int id)
  // {
  //   MangaLibrary.Data.Series? Series = await _context.Seriess
  //     .FirstOrDefaultAsync(r => r.Id == id);

  //   return Series is null ? null : new()
  //   {
  //     Id = Series.Id,
  //     Title = Series.Title,
  //     LastName = Series.LastName,
  //     DateOfBirth = Series.DateOfBirth,
  //     ImageLink = Series.ImageLink
  //   };
  // }

  // public async Task<bool> UpdateSeriesAsync(SeriesEdit model)
  // {
  //   MangaLibrary.Data.Series? entity = await _context.Seriess.FindAsync(model.Id);

  //   if (entity is null)
  //   {
  //     return false;
  //   }

  //   entity.Title = model.Title;
  //   entity.LastName = model.LastName;
  //   entity.DateOfBirth = model.DateOfBirth;
  //   entity.ImageLink = model.ImageLink;
  //   return await _context.SaveChangesAsync() == 1;
  // }

  // public async Task<bool> DeleteSeriesAsync(int id)
  // {
  //   MangaLibrary.Data.Series? entity = await _context.Seriess.FindAsync(id);
  //   if (entity is null)
  //   {
  //     return false;
  //   }

  //   _context.Seriess.Remove(entity);
  //   return await _context.SaveChangesAsync() == 1;
  // }
}