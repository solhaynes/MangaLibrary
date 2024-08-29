using MangaLibrary.Models.Book;

namespace MangaLibrary.Services.Book;

public interface IBookService
{
  Task<List<BookListItem>> GetAllBooksAsync();
  Task<bool> CreateBookAsync(BookCreate model);
  Task<BookDetail?> GetBookDetailAsync(int id);
  Task<bool> UpdateBookAsync(BookEdit model);
  Task<bool> DeleteBookAsync(int id);
}