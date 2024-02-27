using My_Books.Data.Models;

namespace My_Books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1 Book Title",
                        Description = "1 Book Description",
                        isRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "https",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2 Book Title",
                        Description = "2 Book Description",
                        isRead = true,
                        DateRead = DateTime.Now.AddDays(-15),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "https 2 ",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
