namespace My_Books.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
