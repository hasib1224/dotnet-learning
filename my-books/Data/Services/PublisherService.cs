using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Author()
            {
                Name = publisher.Name,
            };
            _context.Authors.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
