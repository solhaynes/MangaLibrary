using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Author;

public class AuthorCreate
{
  [Required, MaxLength(50)]
  public string FirstName { get; set; } = string.Empty;

  [Required,  MaxLength(50)]
  public string LastName { get; set; } = string.Empty;

  [Required]
  public DateOnly DateOfBirth { get; set; }

  [Required]
  public string ImageLink { get; set; } = string.Empty;
}
