using MangaLibrary.Models.Author;

namespace MangaLibrary.Services.Author;

public interface IAuthorService
{
  Task<List<AuthorListItem>> GetAllAuthorsAsync();
  Task<bool> CreateAuthorAsync(AuthorCreate model);
  Task<AuthorDetail?> GetAuthorDetailAsync(int id);
  Task<bool> UpdateAuthorAsync(AuthorEdit model);
  Task<bool> DeleteAuthorAsync(int id);
  Task<List<AuthorList>> GetAuthorSelectListAsync();
}