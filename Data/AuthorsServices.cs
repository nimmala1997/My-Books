using System;
using my_books1.Models;

namespace my_books1.Data
{
	public class AuthorsServices
	{
        public AppDbContext _context;
     
        public AuthorsServices(AppDbContext context)
        {
            _context = context;
        }

        public void Add(AuthorVM _author)
        {
            var author = new Author()
            {
                FullName = _author.Name
            };
            _context.Add(author);
            _context.SaveChanges();
        }
        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }
	}
}

