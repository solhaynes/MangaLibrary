using MangaLibrary.Models.Genre;

namespace MangaLibrary.Services.Genre;

public interface IGenreService
{
  Task<List<GenreListItem>> GetAllGenresAsync();
  Task<bool> CreateGenreAsync(GenreCreate model);
  Task<GenreDetail?> GetGenreDetailAsync(int id);
  Task<bool> UpdateGenreAsync(GenreEdit model);
  Task<bool> DeleteGenreAsync(int id);
  Task<List<GenreList>> GetGenreSelectListAsync();
}