using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaLibrary.Models.Series;
public class SeriesCreate
{
  [Required]
  public string Title { get; set; } = string.Empty;

  [Required]
  public int AuthorId { get; set; }

  [Required]
  public int GenreId { get; set; }

  [Required]
  public string Description { get; set; } = string.Empty;

  [Required]
  public string ImageLink { get; set; } = string.Empty;
}