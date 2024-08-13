using MangaLibrary.Models.Genre;

namespace MangaLibrary.Services.Genre;

public interface IGenreService
{
  Task<List<GenreListItem>> GetAllGenresAsync();
  Task<bool> CreateGenreAsync(GenreCreate model);
 