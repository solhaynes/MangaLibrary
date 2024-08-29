using System.ComponentModel;
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

  public async Task<SeriesDetail?> GetSeriesDetailAsync(int id)
  {
    MangaLibrary.Data.Entities.Series? series = await _context.Series
      .Include(r => r.Author)
      .Include(r => r.Genre)
      .FirstOrDefaultAsync(r => r.Id == id);

    // SeriesDetail seriesDetail = new SeriesDetail();
    return series is null ?  null : new SeriesDetail()
    {
      Id = series.Id,
      Title = series.Title,
      AuthorId = series.AuthorId,
      AuthorName = string.Format($"{series.Author.FirstName} {series.Author.LastName}"),
      GenreId = series.GenreId,
      GenreName = series.Genre.Name,
      Description = series.Description,
      ImageLink = series.ImageLink
    };
  }

  public async Task<bool> UpdateSeriesAsync(SeriesEdit model)
  {
    MangaLibrary.Data.Entities.Series? entity = await _context.Series.FindAsync(model.Id);

    if (entity is null)
    {
      return false;
    }

    entity.Title = model.Title;
    entity.AuthorId = model.AuthorId;
    entity.GenreId = model.GenreId;
    entity.Description = model.Description;
    entity.ImageLink = model.ImageLink;
    return await _context.SaveChangesAsync() == 1;
  }

  public async Task<bool> DeleteSeriesAsync(int id)
  {
    MangaLibrary.Data.Entities.Series? entity = await _context.Series.FindAsync(id);
    if (entity is null)
    {
      return false;
    }

    _context.Series.Remove(entity);
    return await _context.SaveChangesAsync() == 1;
  }

  public async Task<List<SeriesList>> GetSeriesSelectListAsync()
  {
    {
        return _context.Series
            .Select(x => new SeriesList()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
    }
  }
}