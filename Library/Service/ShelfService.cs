using Library.Data;
using Library.Models;
using Library.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class ShelfService : IShelfService
    {
        private readonly ApplicationDbContext _context;
        public ShelfService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateShelf(ShelfVM shelf)
        {
            var newShelf = new ShelfModel()
            {
                Height = shelf.Height,
                Width = shelf.Width,
                LibraryId = shelf.LibaryId,
                Library = _context.Libraries.Where(library => library.Id == shelf.LibaryId).FirstOrDefault(),
            };
            _context.Shelves.Add(newShelf);
            _context.SaveChanges();
        }

        public List<ShelfModel> GetAllShelvesById(long id)
        => _context.Shelves
                    .Include(x => x.Sets)
                    .Where(x => x.LibraryId == id).ToList();

        public void DeleteShelfById(long id)
        {
            ShelfModel? toDelete = _context.Shelves.Find(id);
            if (toDelete != null)
            {
                _context.Shelves.Remove(toDelete);
                _context.SaveChanges();
            }
        }
        public ShelfModel? GetShelfById(long id)
            => _context.Shelves
                .Include(shelf => shelf.Sets)
                .Where(x => x.Id == id)
                .FirstOrDefault();
    }
}
