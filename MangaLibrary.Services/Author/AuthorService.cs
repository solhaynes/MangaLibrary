using MangaLibrary.Data.Entities;
using MangaLibrary.Models.Author;
using MangaLibrary.Services.Author;
using Microsoft.EntityFrameworkCore;

namespace MangaLibrary.Services.Author;

public class AuthorService : IAuthorService
{
  private MangaLibraryDbContext _context;
  public AuthorService(MangaLibraryDbContext context)
  {
    _context = context;
  }

  public async Task<bool> CreateAuthorAsync(AuthorCreate model)
  {
    MangaLibrary.Data.Entities.Author entity = new()
    {
      FirstName = model.FirstName,
      LastName = model.LastName,
      DateOfBirth = model.DateOfBirth,
      ImageLink = model.ImageLink
    };
    _context.Authors.Add(entity);
    return await _context.SaveChangesAsync() == 1;

  }

  public async Task<List<AuthorListItem>> GetAllAuthorsAsync()
  {
    List<AuthorListItem> authors = await _context.Authors
      .Select(r => new AuthorListItem()
      {
        Id = r.Id,
        FirstName = r.FirstName,
        LastName = r.LastName,
        ImageLink = r.ImageLink
      })
      .ToListAsync();

    return authors;
  }

  public async Task<AuthorDetail?> GetAuthorDetailAsync(int id)
  {
    MangaLibrary.Data.Entities.Author? author = await _context.Authors
      .FirstOrDefaultAsync(r => r.Id == id);

    return author is null ? null : new()
    {
      Id = author.Id,
      FirstName = author.FirstName,
      LastName = author.LastName,
      DateOfBirth = author.DateOfBirth,
      ImageLink = author.ImageLink
    };
  }

  public async Task<bool> UpdateAuthorAsync(AuthorEdit model)
  {
    MangaLibrary.Data.Entities.Author? entity = await _context.Authors.FindAsync(model.Id);

    if (entity is null)
    {
      return false;
    }

    entity.FirstName = model.FirstName;
    entity.LastName = model.LastName;
    entity.DateOfBirth = model.DateOfBirth;
    entity.ImageLink = model.ImageLink;
    return await _context.SaveChangesAsync() == 1;
  }

  public async Task<bool> DeleteAuthorAsync(int id)
  {
    MangaLibrary.Data.Entities.Author? entity = await _context.Authors.FindAsync(id);
    if (entity is null)
    {
      return false;
    }

    _context.Authors.Remove(entity);
    return await _context.SaveChangesAsync() == 1;
  }

   public async Task<List<AuthorList>> GetAuthorSelectListAsync()
  {
    {
        return _context.Authors
            .Select(x => new AuthorList()
            {
                Id = x.Id,
                // FirstName = x.FirstName,
                // LastName = x.LastName,
                Name = string.Format($"{x.FirstName} {x.LastName}" )
            }).ToList();
    }
  }
}