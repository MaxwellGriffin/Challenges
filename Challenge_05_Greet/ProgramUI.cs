using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_05_Greet
{
	class ProgramUI
	{
		CustomerRepository customerRepo = new CustomerRepository();
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
					EnterNewCustomer();
					break;
				case "list":
					ListCustomers();
					break;
				case "edit":
					EditCustomer();
					break;
				case "del":
					DeleteCustomer();
					break;
				default:
					Console.WriteLine($"ERROR! '{cmd}' not recognized. Type HELP for options.");
					break;
			}
			ReadCommand();
		}

		public void OnBoot()
		{
			Console.WriteLine("Challenge 5 - Greet\nMaxwell Griffin\n");
			ShowMenu();
			ReadCommand();
		}

		private void ShowMenu()
		{
			Console.WriteLine("\tnew: add new badge\n" +
				"\tlist: list badges\n" +
				"\tedit [badge ID]: edit badge\n" +
			"\thelp: show commands");
		}

		private string StringFitter(string input, int tabs) //Takes a string and returns a string with the correct length in order to fit in a printed list.
		{
			int chars = tabs * 8; //One tab = 8 spaces
			if (input.Length < chars)
			{
				return input.PadRight(chars);
			}
			else if (input.Length > chars)
			{
				return input.Substring(0, chars);
			}
			else
			{
				return input;
			}
		}

		private void EnterNewCustomer()
		{
			Customer newCustomer = new Customer();
			Console.Write("First name:\t");
			newCustomer.FirstName = Console.ReadLine();
			Console.Write("Last name:\t");
			newCustomer.LastName = Console.ReadLine();
			newCustomer.Type = GetCustomerType();
			customerRepo.AddCustomerToList(newCustomer);

		}

		private Customer.CustomerTypes GetCustomerType()
		{
			bool done = false;
			while (!done)
			{
				Console.Write("Type (p/c/f):\t");
				string input = Console.ReadLine().ToLower();
				if (input.Length == 1 && input == "p" || input == "c" || input == "f")
				{
					switch (input)
					{
						case "p":
							return Customer.CustomerTypes.Past;
						case "c":
							return Customer.CustomerTypes.Current;
						case "f":
							return Customer.CustomerTypes.Future;
					}
					done = true;
				}
				else
				{
					Console.WriteLine("ERROR! Invalid customer type (p/c/f).");
				}
			}
			return Customer.CustomerTypes.Current;//wont work unless I add this, but it should never get here
		}

		private void ListCustomers()
		{
			Console.WriteLine();
			Console.WriteLine("#\tFirst Name\tLast Name\tType\t\tMessage\n");
			List<Customer> customerList = customerRepo.GetCustomerList();

			int i = 0;
			foreach (Customer customer in customerList)
			{
				Console.WriteLine($"{i}\t{StringFitter(customer.FirstName, 2)}{StringFitter(customer.LastName, 2)}{customer.Type.ToString()}\t\t{Messager(customer.Type)}");
				i++;
			}
		}

		private string Messager(Customer.CustomerTypes type)
		{
			switch(type)
			{
				case Customer.CustomerTypes.Past:
					return "It's been a long time since we heard from you, we want you back.";
				case Customer.CustomerTypes.Current:
					return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
				case Customer.CustomerTypes.Future:
					return "Take out a life insurance policy on your spouse today and receive a free alibi!";
			}
			return "ERROR";
		}

		private void EditCustomer()
		{
			ListCustomers();
			List<Customer> customerList = customerRepo.GetCustomerList();
			Console.Write("Enter the # of the customer you would like to edit.\t");
			string index = Console.ReadLine();
			int i = 0;
			if (IsDigitsOnly(index) && index.Length == 1)
			{
				i = int.Parse(index);
				if (i <= customerList.Count - 1)
				{
					Customer customer = customerList[i];
					Console.WriteLine("First name:\t" + customer.FirstName);
					Console.Write("First name:\t");
					string input = Console.ReadLine();
					if (input.Replace(" ", string.Empty) != string.Empty)
					{
						customer.FirstName = input;
					}
					Console.WriteLine("Last name:\t" + customer.LastName);
					Console.Write("Last name:\t");
					input = Console.ReadLine();
					if (input.Replace(" ", string.Empty) != string.Empty)
					{
						customer.LastName = input;
					}
					Console.WriteLine("Type:\t" + customer.Type.ToString());
					customer.Type = GetCustomerType();
					customerList[i] = customer;
					customerRepo.SetCustomerList(customerList);
				}
				else
				{
					Console.WriteLine("Customer does not exist at that index.");
				}
			}
			else
			{
				Console.WriteLine("Invalid index.");
			}
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

		private void DeleteCustomer()
		{
			ListCustomers();
			List<Customer> customerList = customerRepo.GetCustomerList();
			Console.Write("Enter the # of the customer you would like to delete.\t");
			string index = Console.ReadLine();
			int i = 0;
			if (IsDigitsOnly(index) && index.Length==1)
			{
				i = int.Parse(index);
				if (i <= customerList.Count - 1)
				{
					customerList.RemoveAt(i);
					customerRepo.SetCustomerList(customerList);
					Console.WriteLine("Deleted.");
				}
				else
				{
					Console.WriteLine("No customer exists at that index.");
				}
			}
			else
			{
				Console.WriteLine("Invalid index.");
			}
		}
	}
}
