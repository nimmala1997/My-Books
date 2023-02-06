using System;
namespace my_books1.Models
{
	public class Publisher
	{
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public List<Book> Books { get; set; }
    }
}

