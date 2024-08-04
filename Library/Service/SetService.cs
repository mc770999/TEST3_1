using Library.Data;
using Library.Models;
using Library.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class SetService : ISetService
    {
        private readonly ApplicationDbContext _context;
        public SetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SetModel> GetAllSetsById(long id)
        => _context.Sets
                    .Include(x => x.Books)
                    .Where(x => x.ShelfId == id).ToList();

        public List<SetModel> GetAllSetsByIdToDelete(long id)
        => _context.Sets
                    .Include(x => x.Books)
                    .Where(x => x.Id == id).ToList();

        public void CreateSet(SetVM newSet)
        {
            var set = new SetModel() { Name = newSet.Name, ShelfId = newSet.ShelfId};
            _context.Sets.Add(set);
            _context.SaveChanges();
        }

        public void DeleteSet(long id)
        {
            SetModel? toDelete = _context.Sets.Find(id);
            if (toDelete != null)
            {
                _context.Sets.Remove(toDelete);
                _context.SaveChanges();
            }
        }
    }
}
