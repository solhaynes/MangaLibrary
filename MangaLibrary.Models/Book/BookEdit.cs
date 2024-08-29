using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Book;

public class BookEdit
{
  public int Id { get; set; }

  [Display(Name="Series")]
  public int SeriesId { get; set; }

  public int Volume { get; set; }
  
  public string Chapters { get; set; } = string.Empty;

  [Display(Name="Release Date")]
  public DateOnly ReleaseDate { get; set; }

  [Display(Name="Image Link")]
  public string ImageLink { get; set; } = string.Empty;
}