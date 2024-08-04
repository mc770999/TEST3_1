using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
    public interface IShelfService
    {
        List<ShelfModel> GetAllShelvesById(long id);
        void CreateShelf(ShelfVM shelf);
        void DeleteShelfById(long id);
        ShelfModel? GetShelfById(long id);
    }
}
