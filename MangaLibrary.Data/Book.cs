using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaLibrary.Data;

public class Book 
{
  [Required]
  public int Id { get; set; }

  [ForeignKey(nameof(Series))]
  public int SeriesId { get; set; }
  public virtual Series Series { get; set; } = null!;

  [Required]
  public int Volume { get; set; }

  [Required]
  public string Chapters { get; set; } = string.Empty;

  public DateOnly ReleaseDate { get; set; }

  [Required]
  public string ImageLink { get; set; } = string.Empty;
}