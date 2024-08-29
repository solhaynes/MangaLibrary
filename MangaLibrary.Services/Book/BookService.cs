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

  public async Task<bool> CreateBookAsync(BookCreate model)
  {
    MangaLibrary.Data.Entities.Book entity = new()
    {
      SeriesId = model.SeriesId,
      Volume = model.Volume,
      Chapters = model.Chapters,
      ReleaseDate = model.ReleaseDate,
      ImageLink = model.ImageLink
    };
    _context.Books.Add(entity);
    return await _context.SaveChangesAsync() == 1;

  }

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

  public async Task<BookDetail?> GetBookDetailAsync(int id)
  {
    MangaLibrary.Data.Entities.Book? book = await _context.Books
      .Include(r => r.Series)
      .FirstOrDefaultAsync(r => r.Id == id);
    return book is null ?  null : new BookDetail()
    {
      Id = book.Id,
      SeriesId = book.SeriesId,
      SeriesName = book.Series.Title,
      Volume = book.Volume,
      Chapters = book.Chapters,
      ReleaseDate = book.ReleaseDate,
      ImageLink = book.ImageLink
    };
  }

  public async Task<bool> UpdateBookAsync(BookEdit model)
  {
    MangaLibrary.Data.Entities.Book? entity = await _context.Books.FindAsync(model.Id);

    if (entity is null)
    {
      return false;
    }

    entity.Id = model.Id;
    entity.SeriesId = model.SeriesId;
    entity.Volume = model.Volume;
    entity.Chapters = model.Chapters;
    entity.ReleaseDate = model.ReleaseDate;
    entity.ImageLink = model.ImageLink;
    return await _context.SaveChangesAsync() == 1;
  }

  public async Task<bool> DeleteBookAsync(int id)
  {
    MangaLibrary.Data.Entities.Book? entity = await _context.Books.FindAsync(id);
    if (entity is null)
    {
      return false;
    }

    _context.Books.Remove(entity);
    return await _context.SaveChangesAsync() == 1;
  }
}