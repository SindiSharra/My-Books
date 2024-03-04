using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModels;
using My_Books.Exceptions;

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
            try
            {
                var _publisher = _publishersSerivce.AddPublisher(publisher);
                return Created(nameof(AddPublisher), _publisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest(ex.Message + "=>" + publisher.Name);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("get-publisher-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var response = _publishersSerivce.getPublisherById(id);
            if(response != null)
            {
                return Ok(response);
            }

            return NotFound();  
        }
        [HttpGet("get-books-by-publisher-id/{id}")]
        public IActionResult GetBooksByPublisher(int id)
        {
            var response = _publishersSerivce.GetPublisherData(id);
            return Ok(response);
        }
        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersSerivce.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
