namespace my_books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation
        public List<Book_Author> Book_Authors { get; set; }
    }
}
