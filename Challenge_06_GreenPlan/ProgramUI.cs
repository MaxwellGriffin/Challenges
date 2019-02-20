using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_06_GreenPlan
{
	class ProgramUI
	{
		CarRepository carRepo = new CarRepository();
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
					EnterNewCar();
					break;
				case "list":
					if(value == "" || value == "g" || value == "e" || value == "h")
					{
						ListCars(value);
						break;
					}
					Console.WriteLine("Invalid.");
					break;
				case "edit":
					if (value == "g" || value == "e" || value == "h")
					{
						EditCar(value);
						break;
					}
					Console.WriteLine("Invalid. You must enter which type of car to edit.");
					break;
				default:
					Console.WriteLine($"ERROR! '{cmd}' not recognized. Type HELP for options.");
					break;
			}
			ReadCommand();
		}

		public void OnBoot()
		{
			Console.WriteLine("Challenge 6 - GreenPlan\nMaxwell Griffin\n");
			ShowMenu();
			ReadCommand();
		}

		private void ShowMenu()
		{
			Console.WriteLine("\tnew: add new car\n" +
				"\tlist: list cars\n" +
				"\tedit [g/e/h]: edit car\n" +
			"\thelp: show commands");
		}

		private void EnterNewCar()
		{
			Car newCar = new Car();
			Console.Write("Make:\t");
			newCar.Make = Console.ReadLine();
			Console.Write("Model:\t");
			newCar.Model = Console.ReadLine();
			newCar.Type = GetCarType();
			string input;
			bool done = false;
			while(!done)
			{
				Console.Write("Cost per mile:\t");
				input = Console.ReadLine();
				if (IsDoubleFormat(input))
				{
					newCar.Cpm = double.Parse(input);
					done = true;
				}
				else
				{
					Console.WriteLine("Invalid format.");
				}
			}
			done = false;
			while(!done)
			{
				Console.Write("Price:\t");
				input = Console.ReadLine();
				if (IsDigitsOnly(input))
				{
					newCar.Price = int.Parse(input);
					done = true;
				}
				else
				{
					Console.WriteLine("Invalid format.");
				}
			}
			switch(newCar.Type)
			{
				case Car.CarType.Gas:
					carRepo.AddCarToList(newCar, "g");
					break;
				case Car.CarType.Electric:
					carRepo.AddCarToList(newCar, "e");
					break;
				case Car.CarType.Hybrid:
					carRepo.AddCarToList(newCar, "h");
					break;
			}
		}

		private void ListCars(string val)
		{
			int i = 0;
			switch (val)
			{
				case "":
					Console.WriteLine("Make\t\tModel\t\tType\t\tCPM\tPrice");
					foreach (Car car in carRepo.GetCarList("g"))
					{
						Console.WriteLine(StringFitter(car.Make, 2) + StringFitter(car.Model, 2) + StringFitter(car.Type.ToString(), 2) + StringFitter(car.Cpm.ToString("C"), 1) + car.Price.ToString("C"));
					}
					foreach (Car car in carRepo.GetCarList("e"))
					{
						Console.WriteLine(StringFitter(car.Make, 2) + StringFitter(car.Model, 2) + StringFitter(car.Type.ToString(), 2) + StringFitter(car.Cpm.ToString("C"), 1) + car.Price.ToString("C"));
					}
					foreach (Car car in carRepo.GetCarList("h"))
					{
						Console.WriteLine(StringFitter(car.Make, 2) + StringFitter(car.Model, 2) + StringFitter(car.Type.ToString(), 2) + StringFitter(car.Cpm.ToString("C"), 1) + car.Price.ToString("C"));
					}
					break;
				case "g":
					Console.WriteLine("#\tMake\t\tModel\t\tType\t\tCPM\tPrice");
					foreach (Car car in carRepo.GetCarList("g"))
					{
						Console.WriteLine(i + "\t" + StringFitter(car.Make, 2) + StringFitter(car.Model, 2) + StringFitter(car.Type.ToString(), 2) + StringFitter(car.Cpm.ToString("C"), 1) + car.Price.ToString("C"));
						i++;
					}
					break;
				case "e":
					Console.WriteLine("#\tMake\t\tModel\t\tType\t\tCPM\tPrice");
					foreach (Car car in carRepo.GetCarList("e"))
					{
						Console.WriteLine(i + "\t" + StringFitter(car.Make, 2) + StringFitter(car.Model, 2) + StringFitter(car.Type.ToString(), 2) + StringFitter(car.Cpm.ToString("C"), 1) + car.Price.ToString("C"));
						i++;
					}
					break;
				case "h":
					Console.WriteLine("#\tMake\t\tModel\t\tType\t\tCPM\tPrice");
					foreach (Car car in carRepo.GetCarList("h"))
					{
						Console.WriteLine(i+ "\t" + StringFitter(car.Make, 2) + StringFitter(car.Model, 2) + StringFitter(car.Type.ToString(), 2) + StringFitter(car.Cpm.ToString("C"), 1) + car.Price.ToString("C"));
						i++;
					}
					break;
				default:
					break;
			}
		}

		private void EditCar(string val)
		{
			ListCars(val);
			List<Car> carList = carRepo.GetCarList(val);
			Console.Write("Enter the # of the car you would like to edit.\t");
			string index = Console.ReadLine();
			int i = 0;
			if (IsDigitsOnly(index) && index.Length == 1)
			{
				i = int.Parse(index);
				if (i <= carList.Count - 1)
				{
					Car car = carList[i];
					Console.WriteLine("Make:\t" + car.Make);
					Console.Write("Make:\t");
					string input = Console.ReadLine();
					if (input.Replace(" ", string.Empty) != string.Empty)
					{
						car.Make = input;
					}
					Console.WriteLine("Model:\t" + car.Model);
					Console.Write("Model:\t");
					input = Console.ReadLine();
					if (input.Replace(" ", string.Empty) != string.Empty)
					{
						car.Model = input;
					}
					Console.WriteLine("Type:\t" + car.Type.ToString());
					car.Type = GetCarType();
					bool done = false;
					while(!done)
					{
						Console.WriteLine("CPM:\t");
						input = Console.ReadLine();
						if (input.Replace(" ", string.Empty) == string.Empty)
						{
							done = true;
						}
						else if (IsDoubleFormat(input))
						{
							car.Cpm = double.Parse(input);
							done = true;
						}
						else
						{
							Console.WriteLine("Incorrect format.");
						}
					}
					done = false;
					while (!done)
					{
						Console.WriteLine("Price:\t");
						input = Console.ReadLine();
						if(input.Replace(" ", string.Empty) == string.Empty)
						{
							done = true;
						}
						else if (IsDigitsOnly(input))
						{
							car.Price = int.Parse(input);
							done = true;
						}
						else
						{
							Console.WriteLine("Incorrect format.");
						}
					}
					carList[i] = car;
					carRepo.SetCarList(carList, val);
					Console.WriteLine("Done editing.");
				}
				else
				{
					Console.WriteLine("Car does not exist at that index.");
				}
			}
			else
			{
				Console.WriteLine("Invalid index.");
			}
		}

		private void DeleteCar(string val)
		{
			ListCars(val);
			List<Car> carList = carRepo.GetCarList(val);
			Console.Write("Enter the # of the car you would like to delete.\t");
			string index = Console.ReadLine();
			int i = 0;
			if (IsDigitsOnly(index) && index.Length == 1)
			{
				i = int.Parse(index);
				if (i <= carList.Count - 1)
				{
					carList.RemoveAt(i);
					carRepo.SetCarList(carList, val);
					Console.WriteLine("Deleted.");
				}
				else
				{
					Console.WriteLine("No car exists at that index.");
				}
			}
			else
			{
				Console.WriteLine("Invalid index.");
			}
		}

		//helper methods

		private Car.CarType GetCarType()
		{
			bool done = false;
			while (!done)
			{
				Console.Write("Type (g/e/h):\t");
				string input = Console.ReadLine().ToLower();
				if (input.Length == 1 && input == "g" || input == "e" || input == "h")
				{
					switch (input)
					{
						case "g":
							return Car.CarType.Gas;
						case "e":
							return Car.CarType.Electric;
						case "h":
							return Car.CarType.Hybrid;
					}
					done = true;
				}
				else
				{
					Console.WriteLine("ERROR! Invalid car type (g/e/h).");
				}
			}
			return Car.CarType.Gas;//wont work unless I add this, but it should never get here
		}

		private bool IsDoubleFormat(string str)
		{
			foreach (char c in str)
			{
				if (c != '.' && c < '0' || c > '9')
				{
					return false;
				}
			}
			return true;
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

		private string StringFitter(string input, int tabs) 
		{
			int chars = tabs * 8; 
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
	}
}
