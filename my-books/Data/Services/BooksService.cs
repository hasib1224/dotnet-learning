using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                DateRead = book.IsRead ? book.DateRead : null,
                Genre = book.Genre,
                IsRead = book.IsRead,
                Rate = book.IsRead ? book.Rate : null
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks(){
            return _context.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(n => n.Id == bookId);
        }

        public Book UpdateBook(int bookId, BookVM updatedBook)
        {
            try
            {
                var _book = _context.Books.FirstOrDefault(book => book.Id == bookId);
                if (_book != null)
                {
                    _book.Title = updatedBook.Title;
                    _book.Author = updatedBook.Author;
                    _book.Description = updatedBook.Description;
                    _book.CoverUrl = updatedBook.CoverUrl;
                    _book.DateRead = updatedBook.DateRead;
                    _book.Genre = updatedBook.Genre;
                    _book.IsRead = updatedBook.IsRead;
                    _book.Rate = updatedBook.Rate;
                    var updatedBookResponse = _context.Books.Update(_book);
                    return updatedBookResponse.Entity;
                }
                else
                {
                    throw new Exception("Books not found for the given id");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the book: {ex.Message}");
            }
        }

       
        public void DeleteBookById(int bookId)
        {
            try
            {
                var _book = _context.Books.FirstOrDefault(book => book.Id == bookId);
                if (_book!= null)
                {
                    _context.Books.Remove(_book);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Books not found for the given id");
                }
            }catch(Exception e)
            {
                throw new Exception($"An error occurred while deleting the book: {e.Message}");
            }
            
        }
    }
}
