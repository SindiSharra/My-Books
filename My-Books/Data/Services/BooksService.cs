using My_Books.Data.Models;
using My_Books.Data.ViewModels;
using System.Threading;

namespace My_Books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _dbContext;
        public BooksService(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                DateRead = book.isRead ? book.DateRead.Value : null,
                Rate = book.isRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                Author = book.Author,
                DateAdded = DateTime.Now

            };
            _dbContext.Add(_book);
            _dbContext.SaveChanges();
        }

        public List<Book> GetAllBooks() => _dbContext.Books.ToList();

        public Book GetBookById(int BookId) => _dbContext.Books.FirstOrDefault(b => b.Id == BookId);

        public Book UpdateBookById(int bookId , BookVM book)
        {
            var _book = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.isRead = book.isRead;
                _book.DateRead = book.isRead ? book.DateRead.Value : null;
                _book.Rate = book.isRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _book.Author = book.Author;

                _dbContext.SaveChanges();
            }

            return _book;

        }

        public void DeleteBookById(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
                _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
        
    }
}
