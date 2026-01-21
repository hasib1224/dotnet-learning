using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _bookService;

        public BooksController(BooksService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBook(book);

            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks= _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book/{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
            var book = _bookService.GetBookById(bookId);
            return Ok(book);
        }

        [HttpPut("update-book/{bookId}")]
        public IActionResult UpdateBooksById(int bookId, [FromBody] BookVM book)
        {
            var updatedBook= _bookService.UpdateBook(bookId, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book/{bookId}")]
        public async Task<IActionResult> DeleteBookById(int bookId)
        {
            try
            {
                _bookService.DeleteBookById(bookId);

                return Ok(new
                {
                    Success = true,
                    Message = "Book deleted successfully."
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = $"{ex.Message}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "An internal error occurred.",
                    Details = ex.Message
                });
            }
        }
    }
} 
 