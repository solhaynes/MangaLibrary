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

  [HttpGet]
  public async Task<IActionResult> Details(int id)
  {
    GenreDetail? model = await _service.GetGenreDetailAsync(id);

    if (model is null)
    {
      return NotFound();
    }

    return View(model);
  }

  // Genre Edit
  [HttpGet]
  public async Task<IActionResult> Edit(int id)
  {
    GenreDetail? genre = await _service.GetGenreDetailAsync(id);
    if (genre is null)
    {
      return NotFound();
    }

    GenreEdit model = new()
    {
      Id = genre.Id,
      Name = genre.Name ?? "",
      Description = genre.Description ?? ""
    };

    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, GenreEdit model)
  {
    if (!ModelState.IsValid)
      return View(model);

    if (await _service.UpdateGenreAsync(model))
      return RedirectToAction(nameof(Details), new { id = id });

    ModelState.AddModelError("Save Error", "Could not update the Genre. Please try again.");
    return View(model);
  }

  //Delete Genre
  [HttpGet]
  public async Task<IActionResult> Delete(int id)
  {
    GenreDetail? genre = await _service.GetGenreDetailAsync(id);
    if (genre is null)
    {
      return RedirectToAction(nameof(Index));
    }

    return View(genre);
  }

  [HttpPost]
  [ActionName(nameof(Delete))]
  public async Task<IActionResult> ConfirmDelete(int id)
  {
    await _service.DeleteGenreAsync(id);
    return RedirectToAction(nameof(Index));
  }
}