using System.ComponentModel;
using MangaLibrary.Data.Entities;
using MangaLibrary.Models.Book;
using MangaLibrary.Services.Book;
using Microsoft.EntityFrameworkCore;

namespace MangaLibrary.Services.Book;

public class BookService : IBookService
{
  private MangaLibraryDbContext _context;
  public BookService(MangaLibraryDbContext context)
  {
    _context = context;
  }

  // public async Task<bool> CreateBookAsync(BookCreate model)
  // {
  //   MangaLibrary.Data.Entities.Book entity = new()
  //   {
  //     Title = model.Title,
  //     AuthorId = model.AuthorId,
  //     GenreId = model.GenreId,
  //     Description = model.Description,
  //     ImageLink = model.ImageLink
  //   };
  //   _context.Book.Add(entity);
  //   return await _context.SaveChangesAsync() == 1;

  // }

  public async Task<List<BookListItem>> GetAllBooksAsync()
  {
    List<BookListItem> books = await _context.Books
      .Include(r => r.Series)
      .Select(r => new BookListItem()
      {
        Id = r.Id,
        Series = r.Series.Title,
        Volume = r.Volume,
        ImageLink = r.ImageLink
      })
      .ToListAsync();

    return books;
  }

  // public async Task<BookDetail?> GetBookDetailAsync(int id)
  // {
  //   MangaLibrary.Data.Entities.Book? Book = await _context.Book
  //     .Include(r => r.Author)
  //     .Include(r => r.Genre)
  //     .FirstOrDefaultAsync(r => r.Id == id);

  //   // BookDetail BookDetail = new BookDetail();
  //   return Book is null ?  null : new BookDetail()
  //   {
  //     Id = Book.Id,
  //     Title = Book.Title,
  //     AuthorId = Book.AuthorId,
  //     AuthorName = string.Format($"{Book.Author.FirstName} {Book.Author.LastName}"),
  //     GenreId = Book.GenreId,
  //     GenreName = Book.Genre.Name,
  //     Description = Book.Description,
  //     ImageLink = Book.ImageLink
  //   };
  // }

  // public async Task<bool> UpdateBookAsync(BookEdit model)
  // {
  //   MangaLibrary.Data.Entities.Book? entity = await _context.Book.FindAsync(model.Id);

  //   if (entity is null)
  //   {
  //     return false;
  //   }

  //   entity.Title = model.Title;
  //   entity.AuthorId = model.AuthorId;
  //   entity.GenreId = model.GenreId;
  //   entity.Description = model.Description;
  //   entity.ImageLink = model.ImageLink;
  //   return await _context.SaveChangesAsync() == 1;
  // }

  // public async Task<bool> DeleteBookAsync(int id)
  // {
  //   MangaLibrary.Data.Entities.Book? entity = await _context.Book.FindAsync(id);
  //   if (entity is null)
  //   {
  //     return false;
  //   }

  //   _context.Book.Remove(entity);
  //   return await _context.SaveChangesAsync() == 1;
  // }
}