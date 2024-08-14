using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Genre;

public class GenreEdit
{
  [Required]
  public int Id { get; set; }
  [Required, StringLength(50)]
  public string Name { get; set; } = string.Empty;
  [Required, StringLength(500)]
  public string Description { get; set; } = string.Empty;
}