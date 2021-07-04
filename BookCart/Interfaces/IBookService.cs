using MovieTheater.Dto;
using MovieTheater.Models;
using System.Collections.Generic;

namespace MovieTheater.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        int AddBook(Book book);
        int UpdateBook(Book book);
        Book GetBookData(int bookId);
        string DeleteBook(int bookId);
        List<Categories> GetCategories();
        List<Book> GetSimilarBooks(int bookId);
        List<CartItemDto> GetBooksAvailableInCart(string cartId);
        List<Book> GetBooksAvailableInWishlist(string wishlistID);
    }
}
