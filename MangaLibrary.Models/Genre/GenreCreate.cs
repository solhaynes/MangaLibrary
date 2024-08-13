using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Genre;

public class GenreCreate
{
  [Required]
  [MinLength(1)]
  public string Name { get; set; } = string.Empty;

  [Required]
  [MinLength(1)]
  public string Description { get; set; } = string.Empty;
}