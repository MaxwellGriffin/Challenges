using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_05_Greet
{
	class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public enum CustomerTypes { Future, Current, Past }
		public CustomerTypes Type { get; set; }
	}
}
