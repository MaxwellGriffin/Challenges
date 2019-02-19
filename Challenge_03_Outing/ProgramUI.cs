using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03_Outing
{
	public class ProgramUI
	{
		OutingRepository _outingRepo = new OutingRepository();

		public void ReadCommand()
		{
			string input = Console.ReadLine();
			string cmd, value="";
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
					AddNewOuting();
					break;
				case "list":
					ListOutings();
					break;
				case "help":
					ShowMenu();
					break;
				case "costof":
					CostOfUI(value);
					break;
				default:
					Console.WriteLine($"ERROR! '{cmd}' not recognized. Type HELP for options.");
					break;
			}
			ReadCommand();
		}

		public void OnBoot()
		{
			Console.WriteLine("Challenge 3 - Outing\nMaxwell Griffin\n");
			ShowMenu();
			ReadCommand();
		}

		public void ShowMenu()
		{
			Console.WriteLine("\tnew: add new outing\n" +
				"\tlist: list outings\n" +
				"\tcostof [a/b/c/g/all]: calculate cost of all outings of selected type\n" +
			"\thelp: show commands");
		}

		public void AddNewOuting()
		{
			Outing temp = new Outing();
			Console.Write("\tOuting type (a/b/c/g):\t");
			switch(Console.ReadLine())
			{
				case "a":
					temp.OutingType = Outing.OutingTypes.AmusementPark;
					break;
				case "b":
					temp.OutingType = Outing.OutingTypes.Bowling;
					break;
				case "c":
					temp.OutingType = Outing.OutingTypes.Concert;
					break;
				case "g":
					temp.OutingType = Outing.OutingTypes.Golf;
					break;
				default:
					break;
			}
			Console.Write("\tAttendence:\t\t");
			temp.Attendence = int.Parse(Console.ReadLine());
			Console.Write("\tDate (MM/DD/YYYY):\t");
			temp.OutingDate = DateTime.Parse(Console.ReadLine());
			Console.Write("\tTicket price:\t\t");
			temp.TicketPrice = double.Parse(Console.ReadLine());
			Console.Write("\tExtra cost:\t\t");
			temp.ExtraCost = double.Parse(Console.ReadLine());
			_outingRepo.SetNewOuting(temp);
		}

		private void ListOutings()
		{
			Console.WriteLine("Type\t\t\tAttendence\tDate\t\tTicket Price\tExtra Cost\tTotal Cost");
			foreach (Outing outing in _outingRepo.GetOutingList())
			{
				Console.WriteLine(StringFitter(outing.OutingType.ToString(), 2) + "\t" + StringFitter(outing.Attendence.ToString(), 1) + "\t" + outing.OutingDate.ToShortDateString() + "\t" + StringFitter(outing.TicketPrice.ToString("C"), 1) + "\t" + StringFitter(outing.ExtraCost.ToString("C"), 1) + "\t" + StringFitter(outing.TotalCost().ToString("C"), 2));
			}
		}

		private string StringFitter(string input, int tabs) //Takes a string and returns a string with the correct length in order to fit in a printed list.
		{
			int chars = tabs * 8; //One tab = 8 spaces
			if (input.Length < chars)
			{
				return input.PadRight(chars);
			}
			else if(input.Length > chars)
			{
				return input.Substring(0, chars);
			}
			else
			{
				return input;
			}
		}

		private void CostOfUI(string x)
		{
			double cost;
			switch(x)
			{
				case "a":
					cost = _outingRepo.CostOf(Outing.OutingTypes.AmusementPark);
					Console.WriteLine("The total cost of all Amusement Park outings was " + cost.ToString("C"));
					break;
				case "b":
					cost = _outingRepo.CostOf(Outing.OutingTypes.Bowling);
					Console.WriteLine("The total cost of all Bowling outings was " + cost.ToString("C"));
					break;
				case "c":
					cost = _outingRepo.CostOf(Outing.OutingTypes.Concert);
					Console.WriteLine("The total cost of all Concert outings was " + cost.ToString("C"));
					break;
				case "g":
					cost = _outingRepo.CostOf(Outing.OutingTypes.Golf);
					Console.WriteLine("The total cost of all Golf outings was " + cost.ToString("C"));
					break;
				case "all":
					cost = _outingRepo.CostOfAll();
					Console.WriteLine("The total cost of all outings was " + cost.ToString("C"));
					break;
				default:
					cost = 0;
					break;
			}

		}
	}
}
