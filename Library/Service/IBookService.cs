using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
	public interface IBookService
	{
		BookModel CreateBook(BookVM bookVM);
		long FindShelfIdBySetId(long id);
		long FindSetById(long id);
		void DeleteBook(long id);
		ShelfModel FindShelfModelBySetId(long id);
	}
}
