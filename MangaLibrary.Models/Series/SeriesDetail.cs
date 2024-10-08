using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Series;

public class SeriesDetail
{
  public int Id { get; set; }

  public string Title { get; set; } = string.Empty;

  public int AuthorId { get; set; }

  [Display(Name="Author")]
  public string AuthorName { get; set; } = string.Empty;

  public int GenreId { get; set; }

  [Display(Name="Genre")]
  public string GenreName { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public string ImageLink { get; set; } = string.Empty;
}