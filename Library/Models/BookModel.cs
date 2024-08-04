using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class BookModel
	{
		[Key]
		public long Id { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 3)]
		public required string Name { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 3)]
		public required string Genre { get; set; }
		[Required]
		public required int Height { get; set; }
		[Required]
		public required int Width { get; set; }
		public long SetId { get; set; }
		public SetModel? Set { get; set; }
	}
}