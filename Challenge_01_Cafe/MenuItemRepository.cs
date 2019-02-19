using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01_Cafe
{
	public class MenuItemRepository
	{
		public List<MenuItem> MenuItems = new List<MenuItem>();

		public void AddItem(MenuItem item)
		{
			MenuItems.Add(item);
		}

		public List<MenuItem> Get()
		{
			return MenuItems;
		}

		public void DeleteItem(int x)
		{
			MenuItems.RemoveAt(x);
		}
	}
}
