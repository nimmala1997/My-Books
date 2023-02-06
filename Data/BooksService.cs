using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using my_books1.Models;

namespace my_books1.Data
{
	public class BooksService
	{
		private AppDbContext _context;
		public BooksService(AppDbContext context)
		{
			_context = context;
		}
		public List<Book> GetBooks()
		{
			var books = _context.Books
						.Include(x => x.Publisher)
						.Include(x => x.Book_Authors)
						.ToList();

			return books;
        }
		public void Add(BookVM bookVM)
		{
			var book = new Book()
			{
				Title = bookVM.Title,
				Description = bookVM.Description,
				IsRead = false,
				Genre = bookVM.Genre,
				CoverUrl = bookVM.CoverUrl,
				DateAdded = DateTime.Now.Date,
				PublisherId = bookVM.PublisherId,
				
			};

			_context.Books.Add(book);
			_context.SaveChanges();

			foreach(var id in bookVM.AuthorIds)
			{
				var _book_author = new Book_Author()
				{
					BookId = book.Id,
					AuthorId = id
				};
				_context.Books_Authors.Add(_book_author);
				_context.SaveChanges();

			}
		}
		public BookwithAuthorsVM bookswithauthors(int id)
		{
			try
			{
				var books = _context.Books.Where(b => b.Id == id).Select(n => new BookwithAuthorsVM()
				{
					Name = n.Title,
					PublisherName = n.Publisher.Name,
					Authors = n.Book_Authors.Select(ni => ni.Author.FullName).ToList()
				}).FirstOrDefault();

				if (books == null)
					throw new Exception();
				else
					return books;
            }
            catch (Exception ex)
            {
			    throw new Exception($"The publisher with id: {id} does not exist");
            }
        }

	}
}

