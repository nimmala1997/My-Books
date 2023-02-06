using System;
namespace my_books1.CustomException
{
	public class PublisherNameException:Exception
	{
		public PublisherNameException()
		{
		}
		public PublisherNameException(string name):base(name)
		{

		}
	}
}

