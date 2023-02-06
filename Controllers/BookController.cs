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
    public class BookController : ControllerBase
    {
        public BooksService _service;

        public BookController(BooksService service)
        {
            _service = service;
        }
        [HttpGet("Get-all-books")]
        public IActionResult GetAllBooks()
        {
           
            var allbooks = _service.GetBooks();
            return Ok(allbooks);
        }
        [HttpPost("Add-book")]
        public IActionResult AddBook([FromBody]BookVM bookVM)
        {
            _service.Add(bookVM);
            return Ok("Succesfully added");
        }
        [HttpGet("book-data{id}")]
        public IActionResult Getbook(int id)
        {
            try
            {
                var book = _service.bookswithauthors(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
}

    }
}
