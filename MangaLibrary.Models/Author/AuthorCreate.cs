using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Author;

public class AuthorCreate
{
  [Required, MaxLength(50)]
  [Display(Name="First Name")]
  public string FirstName { get; set; } = string.Empty;

  [Required,  MaxLength(50)]
  [Display(Name="Last Name")]
  public string LastName { get; set; } = string.Empty;

  [Required]
  [Display(Name="Date of Birth")]
  public DateOnly DateOfBirth { get; set; }

  [Required]
  [Display(Name="Image Link")]
  public string ImageLink { get; set; } = string.Empty;
}
