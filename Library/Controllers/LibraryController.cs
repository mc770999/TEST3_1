using Library.Models;
using Library.Service;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libryService;
        public LibraryController(ILibraryService libryService)
        {
            _libryService = libryService;
        }
        public IActionResult Index()
        {
            return View(_libryService.GetAllLibraries());
        }
        public IActionResult Details(long id)
        {
            LibraryModel? byId = _libryService.GetLibrariesById(id);

            if (byId == null) { return RedirectToAction("Index"); }

            return View(byId);
        }
        public IActionResult Create()
        {

            return View(new LibraryVM());
        }
        [HttpPost]
        public IActionResult Create(LibraryVM libary)
        {
            _libryService.CreateLibrary(libary);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(long id)
        {
            _libryService.DeleteLibrary(id);
            return RedirectToAction("Index");
        }
    }
}
