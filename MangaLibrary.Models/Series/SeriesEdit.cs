using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaLibrary.Models.Series;
public class SeriesEdit
{
  [Required]
  public int Id { get; set;}
  
  [Required]
  public string Title { get; set; } = string.Empty;

  [Required]
  [Display(Name = "Author")]
  public int AuthorId { get; set; }

  [Required]
  [Display(Name = "Genre")]
  public int GenreId { get; set; }

  [Required]
  public string Description { get; set; } = string.Empty;

  [Required]
  public string ImageLink { get; set; } = string.Empty;
}