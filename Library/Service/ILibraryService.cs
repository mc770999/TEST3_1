using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
	public interface ILibraryService
	{
		List<LibraryModel> GetAllLibraries();
		LibraryModel? GetLibrariesById(long id);
        void CreateLibrary(LibraryVM newLibary);
		void DeleteLibrary(long id);
    }
}
