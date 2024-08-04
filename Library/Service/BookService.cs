using Library.Data;
using Library.Models;
using Library.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
	public class BookService : IBookService
	{
		private readonly ApplicationDbContext _context;
		public BookService(ApplicationDbContext context)
		{
			_context = context;
		}

		private bool CanAddBook(int bookWidth,long shelfId,long setId)
		{

			int shelfWidth = _context.Shelves.Where(x => x.Id == shelfId).First().Width;
			int setWidth = _context.Books.Where(x => x.SetId == setId).Sum(book => book.Width);
			if (shelfWidth >= setWidth + bookWidth)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public BookModel CreateBook(BookVM bookVM)
		{
			long shlfId = FindShelfIdBySetId(bookVM.SetId);
			bool canAdd = CanAddBook(bookVM.Width, shlfId, bookVM.SetId);
			long libraryId = FindLibraryIdByShelfId(shlfId);
			string myGenre = _context.Libraries.Where(x => x.Id == libraryId).First().Genre;
			var book = new BookModel()
			{
				Name = bookVM.Name,
				Genre = myGenre,
				Height = bookVM.Height,
				Width = bookVM.Width,
				SetId = bookVM.SetId,
				Set = _context.Sets.Where(set => set.Id == bookVM.SetId).FirstOrDefault()
			};
			_context.Books.Add(book);
			_context.SaveChanges();
			return book;
		}

		public void DeleteBook(long id)
		{
			BookModel? toDelete = _context.Books.Find(id);
			if (toDelete != null)
			{
				_context.Books.Remove(toDelete);
				_context.SaveChanges();
			}
		}

		public long FindSetById(long id)
		=> _context.Books.Where(set => set.Id == id).FirstOrDefault()!.SetId;

		public long FindShelfIdBySetId(long id)
		=> _context.Sets.Where(set => set.Id == id).FirstOrDefault()!.ShelfId;

		public long FindLibraryIdByShelfId(long id)
		=> _context.Shelves.Where(set => set.Id == id).FirstOrDefault()!.LibraryId;

		public ShelfModel FindShelfModelBySetId(long id)
		=> _context.Shelves.Where(shelf => shelf.Id == id).FirstOrDefault();

	}
}
