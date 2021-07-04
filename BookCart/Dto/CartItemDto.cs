using MovieTheater.Models;

namespace MovieTheater.Dto
{
    public class CartItemDto
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
