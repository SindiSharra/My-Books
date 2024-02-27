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

        public void AddBookWithAuthors(BookVM book)
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
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,

            };
            _dbContext.Add(_book);
            _dbContext.SaveChanges();

            foreach (var id in book.AuthorId)
            {
                var book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _dbContext.Books_Authors.Add(book_author);
                _dbContext.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() => _dbContext.Books.ToList();

        public BooksWithAuthorsVM GetBookById(int BookId)
        {
            var Book = _dbContext.Books.Where(b=> b.Id == BookId).Select(book => new BooksWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                DateRead = book.isRead ? book.DateRead.Value : null,
                Rate = book.isRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(b => b.Author.FullName).ToList()
            }).FirstOrDefault();

            return Book;
        }

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
