using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModels;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersSerivce _publishersSerivce;

        public PublishersController(PublishersSerivce publishersSerivce)
        {
            _publishersSerivce = publishersSerivce;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersSerivce.AddPublisher(publisher);
            return Ok(); 
        }
    }
}
