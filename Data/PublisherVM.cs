using System;
namespace my_books1.Data
{
	public class PublisherVM
	{
		public string Name { get; set; }
	}
	public class PublishercompdataVM
	{
		public string Name { get; set; }
		public List<bookwithauthors> books { get; set; }

	}
	public class bookwithauthors
	{
		public string Name { get; set; }
		public List<string> Authors { get; set; }
	}

}

