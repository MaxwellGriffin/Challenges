using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02_Claim
{
	class ProgramUI
	{
		ClaimRepository claimRepo_ = new ClaimRepository();

		public void ReadCommand()
		{
			Console.WriteLine();
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
					EnterNewClaim();
					break;
				case "next":
					NextClaim();
					break;
				case "list":
					ListClaims();
					break;
				case "help":
					ShowMenu();
					break;
				default:
					Console.WriteLine($"ERROR! '{cmd}' not recognized. Type HELP for options.");
					break;
			}
			ReadCommand();
		}

		public void EnterNewClaim()
		{
			Claim newclaim = new Claim();
			newclaim.ClaimID = claimRepo_.GetQueue().Count;
			Console.Write("(C)ar/(H)ome/(T)heft:\t\t");
			newclaim.ClaimType = Console.ReadLine()[0];
			Console.Write("Description:\t\t\t");
			newclaim.Description = Console.ReadLine();
			Console.Write("Amount:\t\t\t\t");
			newclaim.Amount = double.Parse(Console.ReadLine());
			Console.Write("DateOfaccident (MM/DD/YYYY):\t");
			newclaim.DateOfAccident = DateTime.Parse(Console.ReadLine());
			Console.Write("DateOfClaim (MM/DD/YYYY):\t");
			newclaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
			newclaim.IsValid = claimRepo_.ValidityCheck(newclaim.DateOfClaim, newclaim.DateOfAccident);
			claimRepo_.AddToQueue(newclaim);
		}

		public void ListClaims()
		{
			Queue<Claim> claimQueue = claimRepo_.GetQueue();

			Console.WriteLine("ClaimID\tType\tDescription(...)\tAmount\t\t\tDateOfAccident\tDateOfClaim\tIsValid");

			foreach (Claim currentClaim in claimQueue)
			{
				Console.WriteLine(currentClaim.ClaimID + "\t" + currentClaim.TypeOfClaim() + "\t" + FormatDescription(currentClaim) + "\t" + currentClaim.Amount.ToString("C").PadRight(10) + "\t\t" + currentClaim.AccDateShort() + "\t" + currentClaim.ClaimDateShort() + "\t" + currentClaim.IsValid);
			}
		}

		public string FormatDescription(Claim claim)
		{
			string description = claim.Description;
			if (description.Length >= 20)
			{
				return description.Substring(0, 19);
			}
			else
			{
				return description.PadRight(20);
			}
		}

		public void OnBootUp()
		{
			Console.WriteLine("Challenge 2\nMax Griffin\n--------------");
			ShowMenu();
			ReadCommand();
		}

		public void ShowMenu()
		{
			Console.WriteLine("\tnew: add new claim\n" +
				"\tnext: deal with next claim\n" +
				"\tlist: list all claims\n" +
			"\thelp: show commands");
		}

		public void NextClaim()
		{
			Claim claim = claimRepo_.GetQueue().Peek();
			string accDate = claim.DateOfAccident.Date.ToString().Substring(0, 9);
			string claimDate = claim.DateOfClaim.Date.ToString().Substring(0, 9);
			Console.WriteLine("\tHere are the details for the next claim to be handled:\n");
			Console.WriteLine("\tClaim ID:\t\t" + claim.ClaimID);
			Console.WriteLine("\tClaim Type:\t\t" + claim.TypeOfClaim());
			Console.WriteLine("\tDescription:\t\t" + claim.Description);
			Console.WriteLine("\tAmount:\t\t\t" + claim.Amount.ToString("C"));
			Console.WriteLine("\tDate of accident:\t" + claim.AccDateShort());
			Console.WriteLine("\tDate of claim:\t\t" + claim.ClaimDateShort());
			Console.WriteLine("\tValid?\t\t\t" + claim.IsValid);
			Console.Write("\nDo you want to handle this claim now(y / n)?\t");
			switch(Console.ReadLine().ToLower())
			{
				case "y":
					claimRepo_.HandleClaim();
					Console.WriteLine("The claim has been handled.");
					ReadCommand();
					break;
				case "n":
					ReadCommand();
					break;
			}
		}
	}
}
