using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class SetVM
    {


        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        public long ShelfId { get; set; }   
    }
}
