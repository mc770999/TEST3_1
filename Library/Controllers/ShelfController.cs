using Library.Models;
using Library.Service;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Library.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfService _shelfService;
        public ShelfController(IShelfService shelfService)
        {
            _shelfService = shelfService;
        }
        public IActionResult Index(long id)
        {
            ViewBag.Id = id;
            return View(_shelfService.GetAllShelvesById(id));
        }

        public IActionResult Create(long id)
        {
            return View(new ShelfVM() { LibaryId = id });
        }

        [HttpPost]
        public IActionResult Create(ShelfVM shelf)
        {
            _shelfService.CreateShelf(shelf);
            return RedirectToAction("Index", new { id = shelf.LibaryId });
        }

        public IActionResult Delete(long ShelfId, long LibraryId)
        {
            _shelfService.DeleteShelfById(ShelfId);
            return RedirectToAction("Index", new { id = LibraryId });
        }

        public IActionResult Details(long id)
        {
            ShelfModel? byId = _shelfService.GetShelfById(id);

            if (byId == null) { return RedirectToAction("Index",new{ ViewBag.id}); }

            return View(byId);
        }

    }
}
