using Library.Models;
using Library.Service;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService _bookService;
		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		public IActionResult Create(long id)
		{
			return View(new BookVM() { SetId = id });
		}

		[HttpPost]
		public IActionResult Create(BookVM bookVM)
		{
			BookModel book = _bookService.CreateBook(bookVM);
			long shelfId = _bookService.FindShelfIdBySetId(_bookService.FindSetById(book.Id));
			ShelfModel shelf = _bookService.FindShelfModelBySetId(shelfId);
			string error = "";
			if (book.Height <= shelf.Height)
				error = "Book is shorter then shelf";
			return RedirectToAction("Index","Set", new { id = _bookService.FindShelfIdBySetId(bookVM.SetId),error = error });
		}

		public IActionResult Delete(long id) 
		{
			long setId = _bookService.FindSetById(id);
			long shelfId = _bookService.FindShelfIdBySetId(setId);
			_bookService.DeleteBook(id);
			return RedirectToAction("Index","Set",new {id = shelfId});
		}
	}
}
