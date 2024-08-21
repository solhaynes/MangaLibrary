using MangaLibrary.Models.Author;
using MangaLibrary.Services.Author;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.WebMvc.Controllers;

public class AuthorController : Controller
{
  private IAuthorService _service;
  public AuthorController(IAuthorService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<IActionResult> Index()
  {
    List<AuthorListItem> authors= await _service.GetAllAuthorsAsync();
    return View(authors);
  }

  [HttpGet]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Create(AuthorCreate model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    await _service.CreateAuthorAsync(model);

    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public async Task<IActionResult> Details(int id)
  {
    AuthorDetail? model = await _service.GetAuthorDetailAsync(id);

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
    AuthorDetail? author = await _service.GetAuthorDetailAsync(id);
    if (author is null)
    {
      return NotFound();
    }

    AuthorEdit model = new()
    {
      Id = author.Id,
      FirstName = author.FirstName ?? "",
      LastName = author.LastName ?? "",
      DateOfBirth = author.DateOfBirth,
      ImageLink = author.ImageLink,

    };

    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, AuthorEdit model)
  {
    if (!ModelState.IsValid)
      return View(model);

    if (await _service.UpdateAuthorAsync(model))
      return RedirectToAction(nameof(Details), new { id = id });

    ModelState.AddModelError("Save Error", "Could not update the Author. Please try again.");
    return View(model);
  }

  //Delete Genre
  [HttpGet]
  public async Task<IActionResult> Delete(int id)
  {
    AuthorDetail? author = await _service.GetAuthorDetailAsync(id);
    if (author is null)
    {
      return RedirectToAction(nameof(Index));
    }

    return View(author);
  }

  [HttpPost]
  [ActionName(nameof(Delete))]
  public async Task<IActionResult> ConfirmDelete(int id)
  {
    await _service.DeleteAuthorAsync(id);
    return RedirectToAction(nameof(Index));
  }
}