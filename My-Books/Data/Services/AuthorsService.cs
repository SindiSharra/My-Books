using My_Books.Data.Models;
using My_Books.Data.ViewModels;

namespace My_Books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _dbContext;
        public AuthorsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _dbContext.Authors.Add(_author);
            _dbContext.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBOoks(int AuthorId)
        {
            var author = _dbContext.Authors.Where(a => a.Id == AuthorId).Select(a => new AuthorWithBooksVM()
            {
                FullName = a.FullName,
                BookTitles = a.Book_Authors.Select(a => a.book.Title).ToList()
            }).FirstOrDefault();
            return author;
        }

    }
}
