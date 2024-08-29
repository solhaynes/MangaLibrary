namespace MangaLibrary.Models.Book;

public class BookEdit
{
  public int Id { get; set; }
  public int SeriesId { get; set; }
  public int Volume { get; set; }
  public string Chapters { get; set; } = string.Empty;
  public DateOnly ReleaseDate { get; set; }
  public string ImageLink { get; set; } = string.Empty;
}