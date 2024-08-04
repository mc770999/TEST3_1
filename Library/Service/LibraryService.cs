using Library.Data;
using Library.Models;
using Library.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly ApplicationDbContext _context;
        public LibraryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<LibraryModel> GetAllLibraries()
        => _context.Libraries.ToList();

        public void CreateLibrary(LibraryVM newLibary)
        {
            var library = new LibraryModel() { Genre = newLibary.Genre };
            _context.Libraries.Add(library);
            _context.SaveChanges();
        }

        public LibraryModel? GetLibrariesById(long id)
            => _context.Libraries
                .Include(library => library.Shelfs)
                .Where(x => x.Id == id)
                .FirstOrDefault();

        public void DeleteLibrary(long id)
        {
            LibraryModel? toDelete = _context.Libraries.Find(id);
            if (toDelete != null)
            {
                _context.Libraries.Remove(toDelete);
                _context.SaveChanges();
            }
        }
    }
}
