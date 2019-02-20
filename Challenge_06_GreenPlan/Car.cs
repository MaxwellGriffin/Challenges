using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_06_GreenPlan
{
	class Car
	{
		public enum CarType { Gas, Electric, Hybrid }
		public CarType Type { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public double Cpm { get; set; } //Cost per mile in either gas or electricity.
		public int Price { get; set; }
	}
}
