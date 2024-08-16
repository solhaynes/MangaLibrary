using MangaLibrary.Models.Series;

namespace MangaLibrary.Services.Series;

public interface ISeriesService
{
  Task<List<SeriesListItem>> GetAllSeriesAsync();
  // Task<bool> CreateSeriesAsync(SeriesCreate model);
  // Task<SeriesDetail?> GetSeriesDetailAsync(int id);
  // Task<bool> UpdateSeriesAsync(SeriesEdit model);
  // Task<bool> DeleteSeriesAsync(int id);
}