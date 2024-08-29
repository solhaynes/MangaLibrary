using MangaLibrary.Models.Author;
using MangaLibrary.Models.Series;
using MangaLibrary.Models.Book;
using MangaLibrary.Services.Author;
using MangaLibrary.Services.Series;
using MangaLibrary.Services.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MangaLibrary.WebMvc.Controllers;

public class BookController : Controller
{
  private IBookService _bookService;
  private ISeriesService _seriesService;

  public BookController(IBookService BookService, ISeriesService seriesService)
  {
    _bookService = BookService;
    _seriesService = seriesService;
  }

  [HttpGet]
  public async Task<IActionResult> Index()
  {
    List<BookListItem> Book = await _bookService.GetAllBooksAsync();
    return View(Book);
  }

  [HttpGet]
  public async Task<IActionResult> Create()
  {
    List<SeriesList> series = await _seriesService.GetSeriesSelectListAsync();
    var seriesHolder = new SelectList(series, "Id", "Title");
    ViewBag.SeriesDropDownList = seriesHolder;

    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Create(BookCreate model)
  {
    if (!ModelState.IsValid)
    {
      List<SeriesList> series = await _seriesService.GetSeriesSelectListAsync();
      var seriesHolder = new SelectList(series, "Id", "Title");
      ViewBag.SeriesDropDownList = seriesHolder;

      return View(model);
    }

    await _bookService.CreateBookAsync(model);

    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public async Task<IActionResult> Details(int id)
  {
    BookDetail? model = await _bookService.GetBookDetailAsync(id);

    if (model is null)
    {
      return NotFound();
    }

    return View(model);
  }

  // Book Edit
  [HttpGet]
  public async Task<IActionResult> Edit(int id)
  {
    BookDetail? book = await _bookService.GetBookDetailAsync(id);
    if (book is null)
    {
      return NotFound();
    }

    BookEdit model = new()
    {
      Id = book.Id,
      SeriesId = book.SeriesId,
      Volume = book.Volume,
      Chapters = book.Chapters ?? "",
      ReleaseDate = book.ReleaseDate,
      ImageLink = book.ImageLink,

    };

    List<SeriesList> series = await _seriesService.GetSeriesSelectListAsync();
    var seriesHolder = new SelectList(series, "Id", "Title");
    ViewBag.SeriesDropDownList = seriesHolder;

    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, BookEdit model)
  {
    if (!ModelState.IsValid)
      return View(model);

    if (await _bookService.UpdateBookAsync(model))
      return RedirectToAction(nameof(Details), new { id = id });

    ModelState.AddModelError("Save Error", "Could not update the Book. Please try again.");

    List<SeriesList> series = await _seriesService.GetSeriesSelectListAsync();
    var seriesHolder = new SelectList(series, "Id", "Title");
    ViewBag.SeriesDropDownList = seriesHolder;
    
    return View(model);
  }

  //Delete Genre
  [HttpGet]
  public async Task<IActionResult> Delete(int id)
  {
    BookDetail? book = await _bookService.GetBookDetailAsync(id);
    if (book is null)
    {
      return RedirectToAction(nameof(Index));
    }

    return View(book);
  }

  [HttpPost]
  [ActionName(nameof(Delete))]
  public async Task<IActionResult> ConfirmDelete(int id)
  {
    await _bookService.DeleteBookAsync(id);
    return RedirectToAction(nameof(Index));
  }
}