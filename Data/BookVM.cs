using System;
namespace my_books1.Data
{
	public class BookVM
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }

        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
    public class BookwithAuthorsVM
    {
        public string Name { get; set; }
        public string PublisherName { get; set; }
        public List<string> Authors { get; set; }
    }
}

