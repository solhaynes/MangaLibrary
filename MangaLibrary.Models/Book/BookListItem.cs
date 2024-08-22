namespace MangaLibrary.Models.Book;

public class BookListItem
{
  public int Id { get; set;}

  public string Series { get; set; } = string.Empty;

  public int Volume { get; set; }

  public string ImageLink { get; set; } = string.Empty;

}