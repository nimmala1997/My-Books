﻿using System;
namespace my_books1.Models
{
	public class Author
	{
        public int Id { get; set; }
        public string FullName { get; set; }
        

        public List<Book_Author> Book_Authors { get; set; }
    }
}

