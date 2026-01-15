using my_books.Data.Models;
using my_books.Data.ViewModels;

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
    }
}
