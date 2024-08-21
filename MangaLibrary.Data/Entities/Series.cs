using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaLibrary.Data.Entities;

public class Series
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string Title { get; set; } = string.Empty;

  [ForeignKey(nameof(Author))]
  public int AuthorId { get; set; }
  public virtual Author Author { get; set; } = null!;

  [ForeignKey(nameof(Genre))]
  public int GenreId { get; set; }
  public virtual Genre Genre { get; set; } = null!;

  [Required]
  public string Description { get; set; } = string.Empty;

  [Required]
  public string ImageLink { get; set; } = string.Empty;
}