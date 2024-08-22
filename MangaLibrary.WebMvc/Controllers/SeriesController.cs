using MangaLibrary.Models.Author;
using MangaLibrary.Models.Genre;
using MangaLibrary.Models.Series;
using MangaLibrary.Services.Author;
using MangaLibrary.Services.Genre;
using MangaLibrary.Services.Series;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MangaLibrary.WebMvc.Controllers;

public class SeriesController : Controller
{
  private ISeriesService _seriesService;
  private IGenreService _genreService;
  private IAuthorService _authorService;

  public SeriesController(ISeriesService seriesService, IGenreService genreService, IAuthorService authorService)
  {
    _seriesService = seriesService;
    _genreService = genreService;
    _authorService = authorService;
  }

  [HttpGet]
  public async Task<IActionResult> Index()
  {
    List<SeriesListItem> series = await _seriesService.GetAllSeriesAsync();
    return View(series);
  }

  [HttpGet]
  public async Task<IActionResult> Create()
  {
    List<GenreList> genres = await _genreService.GetGenreSelectListAsync();
    var genreHolder = new SelectList(genres, "Id", "Name");
    ViewBag.GenreDropDownList = genreHolder;

    List<AuthorList> authors = await _authorService.GetAuthorSelectListAsync();
    var authorHolder = new SelectList(authors, "Id", "Name");
    ViewBag.AuthorDropDownList = authorHolder;
    
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Create(SeriesCreate model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    await _seriesService.CreateSeriesAsync(model);

    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public async Task<IActionResult> Details(int id)
  {
    SeriesDetail? model = await _seriesService.GetSeriesDetailAsync(id);

    if (model is null)
    {
      return NotFound();
    }

    return View(model);
  }

  // Series Edit
  [HttpGet]
  public async Task<IActionResult> Edit(int id)
  {
    SeriesDetail? Series = await _seriesService.GetSeriesDetailAsync(id);
    if (Series is null)
    {
      return NotFound();
    }

    SeriesEdit model = new()
    {
      Id = Series.Id,
      Title = Series.Title ?? "",
      AuthorId = Series.AuthorId,
      GenreId = Series.GenreId,
      Description = Series.Description ?? "",
      ImageLink = Series.ImageLink,

    };

    List<GenreList> genres = await _genreService.GetGenreSelectListAsync();
    var genreHolder = new SelectList(genres, "Id", "Name");
    ViewBag.GenreDropDownList = genreHolder;

    List<AuthorList> authors = await _authorService.GetAuthorSelectListAsync();
    var authorHolder = new SelectList(authors, "Id", "Name");
    ViewBag.AuthorDropDownList = authorHolder;

    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, SeriesEdit model)
  {
    if (!ModelState.IsValid)
      return View(model);

    if (await _seriesService.UpdateSeriesAsync(model))
      return RedirectToAction(nameof(Details), new { id = id });

    ModelState.AddModelError("Save Error", "Could not update the series. Please try again.");
    return View(model);
  }

  //Delete Genre
  [HttpGet]
  public async Task<IActionResult> Delete(int id)
  {
    SeriesDetail? Series = await _seriesService.GetSeriesDetailAsync(id);
    if (Series is null)
    {
      return RedirectToAction(nameof(Index));
    }

    return View(Series);
  }

  [HttpPost]
  [ActionName(nameof(Delete))]
  public async Task<IActionResult> ConfirmDelete(int id)
  {
    await _seriesService.DeleteSeriesAsync(id);
    return RedirectToAction(nameof(Index));
  }
}