using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01_Cafe
{
	public class ProgramUI
	{
		MenuItemRepository menuItemRepo = new MenuItemRepository();

		public void OnBootUp()
		{
			Console.WriteLine("Challenge 1\nMax Griffin\n--------------");
			ShowMenu();
			ReadCommand();
		}

		public void ShowMenu()
		{
			Console.WriteLine("\tnew: create new menu item\n" +
				"\tdel [index]: delete menu item\n" +
				"\tlist: list all menu items");
		}

		public void NewItem()
		{
			MenuItem tempItem = new MenuItem();
			Console.Write("Name:\t\t");
			tempItem.Name = Console.ReadLine();
			Console.Write("Description:\t");
			tempItem.Description = Console.ReadLine();
			Console.Write("Ingredients:\t");
			tempItem.Ingredients = Console.ReadLine();
			Console.Write("Price:\t\t");
			tempItem.Price = double.Parse(Console.ReadLine());
			menuItemRepo.AddItem(tempItem);
		}

		public void DeleteItem(int x)
		{
			string name = menuItemRepo.Get()[x].Name;
			menuItemRepo.DeleteItem(x);
			Console.WriteLine($"'{name}' successfully deleted.");
		}

		public void ListItems()
		{
			int x = 0;
			foreach(MenuItem item in menuItemRepo.Get())
			{
				Console.WriteLine("Index:\t\t" + x);
				Console.WriteLine("Name:\t\t" + item.Name);
				Console.WriteLine("Description:\t" + item.Description);
				Console.WriteLine("Ingredients:\t" + item.Ingredients);
				Console.WriteLine("Price:\t\t" + item.Price.ToString("C"));
				Console.WriteLine();
				x++;
			}

		}

		public void ReadCommand()
		{
			string input = Console.ReadLine();
			string cmd, value = "";
			if (input.Contains(" "))
			{
				int space = input.IndexOf(" ");
				value = input.Substring(space + 1);
				cmd = input.Substring(0, space);
			}
			else
			{
				cmd = input;
			}

			switch (cmd.ToLower())
			{
				case "new":
					Console.WriteLine();
					NewItem();
					break;
				case "del":
					Console.WriteLine();
					DeleteItem(int.Parse(value));
					break;
				case "list":
					ListItems();
					break;
				case "help":
					Console.WriteLine();
					ShowMenu();
					break;
				default:
					Console.WriteLine($"ERROR! '{cmd}' not recognized. Type HELP for options.");
					break;
			}
			Console.WriteLine();
			ReadCommand();
		}

	}
}
