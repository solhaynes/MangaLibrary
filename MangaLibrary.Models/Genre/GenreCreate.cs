using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Genre;

public class GenreCreate
{
  [Required]
  [MaxLength(50)]
  public string Name { get; set; } = string.Empty;

  [Required]
  [MaxLength(500)]
  public string Description { get; set; } = string.Empty;
}