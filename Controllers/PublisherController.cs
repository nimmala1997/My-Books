using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books1.CustomException;
using my_books1.Data;

namespace my_books1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public PublishersService _service;
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(PublishersService service, ILogger<PublisherController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpPost("Add-Publisher")]
        public IActionResult Add([FromBody]PublisherVM publisherVM)
        {
            try
            {
                _service.Add(publisherVM);
                return Ok("Publisher added succesfully to database");
            }
            catch(PublisherNameException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-all-publishers")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Publisher getall method entered");
            var publishers = _service.GetAll();
            return Ok(publishers);
        }
        [HttpGet("get-publisher-with-data{id}")]
        public IActionResult Getdata(int id)
        {
            var publisher = _service.Getalldata(id);
            return Ok(publisher);
        }
    }
}
