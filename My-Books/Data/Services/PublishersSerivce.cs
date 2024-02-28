using My_Books.Data.Models;
using My_Books.Data.ViewModels;

namespace My_Books.Data.Services
{
    public class PublishersSerivce
    {
        private AppDbContext _dbcontext;
        public PublishersSerivce(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _dbcontext.Publishers.Add(_publisher);
            _dbcontext.SaveChanges();
        }

        public PublisherWithBooksVM GetPublisherData(int publisherId)
        {
            var publisher = _dbcontext.Publishers.Where(p => p.Id == publisherId)
                .Select(p => new PublisherWithBooksVM()
                {
                    Name = p.Name,
                    BookAuthors = p.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return publisher;
        }

        public void DeletePublisherById(int id)
        {
            var publisher = _dbcontext.Publishers.FirstOrDefault(p => p.Id == id);
            if(publisher != null)
            {
                _dbcontext.Publishers.Remove(publisher);
                _dbcontext.SaveChanges();
            }
        }
    }
}
