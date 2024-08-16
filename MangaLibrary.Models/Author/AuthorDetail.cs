using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Author;

public class AuthorDetail
{
  public int Id { get; set;}

  public string FirstName { get; set; } = string.Empty;

  public string LastName { get; set; } = string.Empty;

  public DateOnly DateOfBirth { get; set; }

  public string ImageLink { get; set; } = string.Empty;

}