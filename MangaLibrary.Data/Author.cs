using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaLibrary.Data;

public class Author 
{
  [Key]
  public int Id { get; set;}

  [Required]
  public string FirstName { get; set; } = string.Empty;

  [Required]
  public string LastName { get; set; } = string.Empty;

  [Required]
  public DateOnly DateOfBirth { get; set; }

  [Required]
  public string ImageLink { get; set; } = string.Empty;

}
