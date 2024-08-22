using MangaLibrary.Models.Author;
using MangaLibrary.Models.Genre;
using MangaLibrary.Models.Book;
using MangaLibrary.Services.Author;
using MangaLibrary.Services.Genre;
using MangaLibrary.Services.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MangaLibrary.WebMvc.Controllers;

public class BookController : Controller
{
  private IBookService _bookService;
  private IGenreService _genreService;
  private IAuthorService _authorService;

  public BookController(IBookService BookService, IGenreService genreService)
  {
    _bookService = BookService;
    _genreService = genreService;
  }

  [HttpGet]
  public async Task<IActionResult> Index()
  {
    List<BookListItem> Book = await _bookService.GetAllBooksAsync();
    return View(Book);
  }

  // [HttpGet]
  // public async Task<IActionResult> Create()
  // {
  //   List<GenreList> genres = await _genreService.GetGenreSelectListAsync();
  //   var genreHolder = new SelectList(genres, "Id", "Name");
  //   ViewBag.GenreDropDownList = genreHolder;

  //   List<AuthorList> authors = await _authorService.GetAuthorSelectListAsync();
  //   var authorHolder = new SelectList(authors, "Id", "Name");
  //   ViewBag.AuthorDropDownList = authorHolder;
    
  //   return View();
  // }

  // [HttpPost]
  // public async Task<IActionResult> Create(BookCreate model)
  // {
  //   if (!ModelState.IsValid)
  //   {
  //     return View(model);
  //   }

  //   await _BookService.CreateBookAsync(model);

  //   return RedirectToAction(nameof(Index));
  // }

  // [HttpGet]
  // public async Task<IActionResult> Details(int id)
  // {
  //   BookDetail? model = await _BookService.GetBookDetailAsync(id);

  //   if (model is null)
  //   {
  //     return NotFound();
  //   }

  //   return View(model);
  // }

  // // Book Edit
  // [HttpGet]
  // public async Task<IActionResult> Edit(int id)
  // {
  //   BookDetail? Book = await _BookService.GetBookDetailAsync(id);
  //   if (Book is null)
  //   {
  //     return NotFound();
  //   }

  //   BookEdit model = new()
  //   {
  //     Id = Book.Id,
  //     Title = Book.Title ?? "",
  //     AuthorId = Book.AuthorId,
  //     GenreId = Book.GenreId,
  //     Description = Book.Description ?? "",
  //     ImageLink = Book.ImageLink,

  //   };

  //   List<GenreList> genres = await _genreService.GetGenreSelectListAsync();
  //   var genreHolder = new SelectList(genres, "Id", "Name");
  //   ViewBag.GenreDropDownList = genreHolder;

  //   List<AuthorList> authors = await _authorService.GetAuthorSelectListAsync();
  //   var authorHolder = new SelectList(authors, "Id", "Name");
  //   ViewBag.AuthorDropDownList = authorHolder;

  //   return View(model);
  // }

  // [HttpPost]
  // public async Task<IActionResult> Edit(int id, BookEdit model)
  // {
  //   if (!ModelState.IsValid)
  //     return View(model);

  //   if (await _BookService.UpdateBookAsync(model))
  //     return RedirectToAction(nameof(Details), new { id = id });

  //   ModelState.AddModelError("Save Error", "Could not update the Book. Please try again.");
  //   return View(model);
  // }

  // //Delete Genre
  // [HttpGet]
  // public async Task<IActionResult> Delete(int id)
  // {
  //   BookDetail? Book = await _BookService.GetBookDetailAsync(id);
  //   if (Book is null)
  //   {
  //     return RedirectToAction(nameof(Index));
  //   }

  //   return View(Book);
  // }

  // [HttpPost]
  // [ActionName(nameof(Delete))]
  // public async Task<IActionResult> ConfirmDelete(int id)
  // {
  //   await _BookService.DeleteBookAsync(id);
  //   return RedirectToAction(nameof(Index));
  // }
}