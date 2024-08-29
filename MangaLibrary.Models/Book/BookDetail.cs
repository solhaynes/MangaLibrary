using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Models.Book;

public class BookDetail
{
  public int Id { get; set; }
  public int SeriesId { get; set; }
  
  [Display(Name="Series")]
  public string SeriesName { get; set; } = string.Empty;
  public int Volume { get; set; }
  public string Chapters { get; set; } = string.Empty;

  [Display(Name="Release Date")]
  public DateOnly ReleaseDate { get; set; }
  public string ImageLink { get; set; } = string.Empty;
}