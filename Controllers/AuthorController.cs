using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books1.Data;

namespace my_books1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public AuthorsServices _service;
        public AuthorController(AuthorsServices service)
        {
            _service = service;
        }
        [HttpGet("Get-all-authors")]
        public IActionResult GetAll()
        {
            var producers = _service.GetAll();
            return Ok(producers);
        }
        [HttpPost("Add-Authors")]
        public IActionResult Add([FromBody]AuthorVM authorVM)
        {
            _service.Add(authorVM);
            return Ok("Succesfully Added");
        }
      
    }
}
