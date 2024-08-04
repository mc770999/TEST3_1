using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class SetModel
	{
		public long Id { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 3)]
		public required string Name { get; set; }
		public long ShelfId { get; set; }
		public ShelfModel? Shelf { get; set; }
		public List<BookModel> Books { get; set; } = [];
	}
}