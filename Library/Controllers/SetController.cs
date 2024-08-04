using Library.Models;
using Library.Service;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class SetController : Controller
    {
        private readonly ISetService _setService;
        public SetController(ISetService setService)
        {
            _setService = setService;
        }
        public IActionResult Index(long id ,string error = "")
        {
            if(error != "")
                ViewBag.ErrorMessage = error;
            ViewBag.Id = id;
            return View(_setService.GetAllSetsById(id));
        }

        public IActionResult Create(long id)
        {
            var a = new SetVM() { ShelfId = id };
            return View(a);
        }
        [HttpPost]
        public IActionResult Create(SetVM set)
        {
            _setService.CreateSet(set);
            return RedirectToAction("Index", new { id = set.ShelfId });
        }
        public IActionResult Delete(long id)
        {
            var a = _setService.GetAllSetsByIdToDelete(id);
            var b = a[0].ShelfId;
              _setService.DeleteSet(id);
            return RedirectToAction("Index", new { id = b });
        }
    }
}
