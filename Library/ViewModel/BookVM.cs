using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
	public class BookVM
	{
		[StringLength(100, MinimumLength = 3)]
		public string Name { get; set; } = string.Empty;

		[StringLength(100, MinimumLength = 3)]
		public string Genre { get; set; } = string.Empty;

		public  int Height { get; set; }

		public  int Width { get; set; }

		public long SetId { get; set; }
	}
}
