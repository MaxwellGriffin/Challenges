using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03_Outing
{
	public class Outing
	{
		public enum OutingTypes { Golf, Bowling, AmusementPark, Concert }
		public OutingTypes? OutingType { get; set; } //idk why ? is there. found online, works both ways
		public int Attendence { get; set; }
		public DateTime OutingDate { get; set; }
		public double TicketPrice { get; set; }
		public double ExtraCost { get; set; }

		public double TotalCost()
		{
			return (TicketPrice * Attendence) + ExtraCost;
		}
	}
}
