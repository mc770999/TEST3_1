using Library.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
	public class LibraryVM
	{
		[ StringLength(100, MinimumLength = 3)]
		public  string Genre { get; set; } = string.Empty;
	}
}
