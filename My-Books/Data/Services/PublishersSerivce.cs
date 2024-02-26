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
    }
}
