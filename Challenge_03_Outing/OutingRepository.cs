using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03_Outing
{
	public class OutingRepository
	{
		List<Outing> outingList = new List<Outing>();

		public void SetNewOuting(Outing newOuting)
		{
			outingList.Add(newOuting);
		}

		public List<Outing> GetOutingList()
		{
			return outingList;
		}

		public double CostOf(Outing.OutingTypes x)
		{
			double total = 0;
			foreach(Outing outing in outingList)
			{
				if(outing.OutingType == x)
				{
					total += outing.TotalCost();
				}
			}
			return total;
		}

		public double CostOfAll()
		{
			double total = 0;
			foreach(Outing outing in outingList)
			{
				total += outing.TotalCost();
			}
			return total;
		}
	}
}
