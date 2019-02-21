using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
 
namespace Challenge_06_GreenPlan
{
	//I began rewriting this class after my dad gave me advice on how to do it better. 
	//The program was working before, but was not written very well.
	public class CarRepository 
	{
		private Dictionary<CarType, List<Car>> cars = new Dictionary<CarType, List<Car>>();
		
		public CarRepository()
		{
			cars[CarType.Electric] = new List<Car>();
			cars[CarType.Hybrid] = new List<Car>();
			cars[CarType.Gas] = new List<Car>();
		}

		public IEnumerable<Car> GetCarList(CarType type)
		{
			return cars[type];
		}

		public void SetCarList(List<Car> inputList)
		{
			foreach (Car car in inputList)
			{
				cars[car.Type].Clear();
			}
			
			foreach (Car car in inputList)
			{
				cars[car.Type].Add(car);
			}
		}

		public void AddCarToList(Car newCar)
		{
			cars[newCar.Type].Add(newCar);
		}
	}
}
