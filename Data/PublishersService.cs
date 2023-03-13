using System;
using System.Text.RegularExpressions;
using my_books1.CustomException;
using my_books1.Models;

namespace my_books1.Data
{
	public class PublishersService
	{
		private AppDbContext _context;
		public PublishersService(AppDbContext context)
		{
			_context = context;
		}
		public void Add(PublisherVM publisherVM)
		{
			if (CheckPublisher(publisherVM))
			{
				var publisher = new Publisher()
				{
					Name = publisherVM.Name
				};
				_context.Publishers.Add(publisher);
				_context.SaveChanges();
			}
			else
			{
				throw new PublisherNameException("Name cannot start with number");
			}
		}
		public List<Publisher> GetAll()
		{
			return _context.Publishers.ToList();
		}
		public PublishercompdataVM Getalldata(int id)
		{
			var publisher = _context.Publishers.Where(n => n.Id == id)
							.Select(n => new PublishercompdataVM()
							{
								Name = n.Name,
								books = n.Books.Select(n => new bookwithauthors()
								{
									Name = n.Title,
									Authors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
								}).ToList()
							}).FirstOrDefault();
			return publisher;
		}
		public PublisherbooksVM GetBooks(int id)
		{
			var publisher = _context.Publishers.Where(x => x.Id == id)
							 .Select(x => new PublisherbooksVM()
							 {
								 Name = x.Name,
								 Books = x.Books.Select(x => x.Title).ToList()
							 }).FirstOrDefault();

			return publisher;
		}
		/*public List<string> Publisherbooks(int id)
		{
			var books = _context.Publishers.Where(x => x.Id == id)
						.SelectMany(x => x.Books)
						.Select(x => x.Title).ToList();

			return books;
		}*/

		public bool CheckPublisher(PublisherVM publisherVM)
		{
			return (Regex.IsMatch(publisherVM.Name, @"^/d"));
		}
	}
}

