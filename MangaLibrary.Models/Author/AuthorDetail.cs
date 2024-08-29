using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Author;

public class AuthorDetail
{
  public int Id { get; set;}

  [Display(Name="First Name")]
  public string FirstName { get; set; } = string.Empty;

  [Display(Name="Last Name")]
  public string LastName { get; set; } = string.Empty;

  [Display(Name="Date of Birth")]
  public DateOnly DateOfBirth { get; set; }

  public string ImageLink { get; set; } = string.Empty;

}