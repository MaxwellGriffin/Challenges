using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04_Badge
{
	class ProgramUI
	{
		BadgeRepository badgeRepo = new BadgeRepository();

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
					InputNewBadge();
					break;
				case "list":
					ListAllBadges();
					break;
				case "help":
					ShowMenu();
					break;
				case "edit":
					if (value != "" && IsDigitsOnly(value)==true && badgeRepo.GetBadgeDictionary().ContainsKey(int.Parse(value)))
					{
						EditBadge(int.Parse(value));
						break;
					}
					Console.WriteLine("You have to enter the badge ID! (ex. edit 12345)");
					break;
				default:
					Console.WriteLine($"ERROR! '{cmd}' not recognized. Type HELP for options.");
					break;
			}
			ReadCommand();
		}

		public void OnBoot()
		{
			Console.WriteLine("Challenge 4 - Badge\nMaxwell Griffin\n");
			ShowMenu();
			ReadCommand();
		}

		private bool IsDigitsOnly(string str)
		{
			foreach (char c in str)
			{
				if (c < '0' || c > '9')
				{
					return false;
				}
			}
			return true;
		}

		public void ShowMenu()
		{
			Console.WriteLine("\tnew: add new badge\n" +
				"\tlist: list badges\n" +
				"\tedit [badge ID]: edit badge\n" +
			"\thelp: show commands");
		}

		public void InputNewBadge()
		{
			Badge temp = new Badge();
			Console.Write("Badge ID #####:\t\t\t\t");

			bool done = false;
			string input;
			while (!done)
			{
				input = Console.ReadLine();
				if (input.Length == 5 && IsDigitsOnly(input) && !badgeRepo.GetBadgeDictionary().ContainsKey(int.Parse(input)))
				{
					temp.BadgeID = int.Parse(input);
					done = true;
				}
				else
				{
					Console.WriteLine("Badge ID must be 5 digits and cannot already exist.");
					Console.Write("Badge ID #####:\t\t\t\t");
				}
			}

			Console.Write("Door access list (seperate by commas):\t");
			string doorlist = Console.ReadLine();
			temp.DoorList = doorlist.ToUpper().Replace(" ", string.Empty).Split(',').ToList();
			badgeRepo.AddNewBadge(temp);
		}

		private void ListAllBadges()
		{
			Console.WriteLine("Badge ID\tDoors");

			foreach (KeyValuePair<int, Badge> pair in badgeRepo.GetBadgeDictionary())
			{
				Console.WriteLine(pair.Value.BadgeID + "\t\t" + string.Join(", ", pair.Value.DoorList));
			}

		}

		private void EditBadge(int id)
		{
			Badge tempBadge = badgeRepo.GetBadgeDictionary()[id];
			Console.WriteLine("Now editing badge #" + id + ". Type add or del to add or delete doors.");

			string input = Console.ReadLine();

			string doorlist;
			switch (input.ToLower())
			{
				case "del":
					Console.Write("Type * to delete all.\nDoors to delete (seperate by commas):\t");
					doorlist = Console.ReadLine();
					if (doorlist == "*")
					{
						tempBadge.DoorList.Clear();
						break;
					}
					tempBadge.DoorList = tempBadge.DoorList.Except(doorlist.ToUpper().Replace(" ", string.Empty).Split(',').ToList()).ToList();
					break;
				case "add":
					Console.Write("Doors to add (seperate by commas):\t");
					doorlist = Console.ReadLine();
					string doorlist1 = doorlist;
					tempBadge.DoorList.AddRange(doorlist1.ToUpper().Replace(" ", string.Empty).Split(',').ToList());
					break;
			}
			Console.WriteLine("Done editing.");
		}
	}
}
