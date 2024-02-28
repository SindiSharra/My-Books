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
        [HttpPost("get-books-by-publisher-id/{id}")]
        public IActionResult GetBooksByPublisher(int id)
        {
            var response = _publishersSerivce.GetPublisherData(id);
            return Ok(response);
        }
        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publishersSerivce.DeletePublisherById(id);
            return Ok();
        }
    }
}
