using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_06_GreenPlan
{
	class CarRepository
	{
		List<Car> gCarList = new List<Car>();
		List<Car> eCarList = new List<Car>();
		List<Car> hCarList = new List<Car>();

		public List<Car> GetCarList(string type)
		{
			switch(type)
			{
				case "g":
					return gCarList;
				case "e":
					return eCarList;
				case "h":
					return hCarList;
				default:
					throw new Exception("Error.");
			}
		}

		public void SetCarList(List<Car> inputList, string type)
		{
			switch (type)
			{
				case "g":
					gCarList = inputList;
					break;
				case "e":
					eCarList = inputList;
					break;
				case "h":
					hCarList = inputList;
					break;
				default:
					throw new Exception("Error.");
			}
		}

		public void AddCarToList(Car newCar, string type)
		{
			switch (type)
			{
				case "g":
					gCarList.Add(newCar);
					break;
				case "e":
					eCarList.Add(newCar);
					break;
				case "h":
					hCarList.Add(newCar);
					break;
				default:
					throw new Exception("Error.");
			}
		}
	}
}
