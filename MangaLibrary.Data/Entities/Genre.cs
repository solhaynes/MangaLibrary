using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Data.Entities;

public class Genre
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = string.Empty;

  [Required]
  public string Description { get; set; } = string.Empty;
}