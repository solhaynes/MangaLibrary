using MangaLibrary.Models.Genre;
using MangaLibrary.Services.Genre;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.WebMvc.Controllers;

public class GenreController : Controller
{
  private IGenreService _service;
  public GenreController(IGenreService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<IActionResult> Index()
  {
    List<GenreListItem> genres = await _service.GetAllGenresAsync();
    return View(genres);
  }

  [HttpGet]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Create(GenreCreate model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    await _service.CreateGenreAsync(model);

    return RedirectToAction(nameof(Index));
  }

