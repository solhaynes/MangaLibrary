using MangaLibrary.Models.Series;
using MangaLibrary.Services.Series;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.WebMvc.Controllers;

public class SeriesController : Controller
{
  private ISeriesService _service;
  public SeriesController(ISeriesService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<IActionResult> Index()
  {
    List<SeriesListItem> genres = await _service.GetAllSeriesAsync();
    return View(genres);
  }

  // [HttpGet]
  // public IActionResult Create()
  // {
  //   return View();
  // }

  // [HttpPost]
  // public async Task<IActionResult> Create(SeriesCreate model)
  // {
  //   if (!ModelState.IsValid)
  //   {
  //     return View(model);
  //   }

  //   await _service.CreateSeriesAsync(model);

  //   return RedirectToAction(nameof(Index));
  // }

  // [HttpGet]
  // public async Task<IActionResult> Details(int id)
  // {
  //   SeriesDetail? model = await _service.GetSeriesDetailAsync(id);

  //   if (model is null)
  //   {
  //     return NotFound();
  //   }

  //   return View(model);
  // }

  // // Genre Edit
  // [HttpGet]
  // public async Task<IActionResult> Edit(int id)
  // {
  //   SeriesDetail? Series = await _service.GetSeriesDetailAsync(id);
  //   if (Series is null)
  //   {
  //     return NotFound();
  //   }

  //   SeriesEdit model = new()
  //   {
  //     Id = Series.Id,
  //     FirstName = Series.FirstName ?? "",
  //     LastName = Series.LastName ?? "",
  //     DateOfBirth = Series.DateOfBirth,
  //     ImageLink = Series.ImageLink,

  //   };

  //   return View(model);
  // }

  // [HttpPost]
  // public async Task<IActionResult> Edit(int id, SeriesEdit model)
  // {
  //   if (!ModelState.IsValid)
  //     return View(model);

  //   if (await _service.UpdateSeriesAsync(model))
  //     return RedirectToAction(nameof(Details), new { id = id });

  //   ModelState.AddModelError("Save Error", "Could not update the Series. Please try again.");
  //   return View(model);
  // }

  // //Delete Genre
  // [HttpGet]
  // public async Task<IActionResult> Delete(int id)
  // {
  //   SeriesDetail? Series = await _service.GetSeriesDetailAsync(id);
  //   if (Series is null)
  //   {
  //     return RedirectToAction(nameof(Index));
  //   }

  //   return View(Series);
  // }

  // [HttpPost]
  // [ActionName(nameof(Delete))]
  // public async Task<IActionResult> ConfirmDelete(int id)
  // {
  //   await _service.DeleteSeriesAsync(id);
  //   return RedirectToAction(nameof(Index));
  // }
}