using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02_Claim
{
	public class ClaimRepository
	{
		Queue<Claim> ClaimQueue = new Queue<Claim>();

		public void AddToQueue(Claim claim)
		{
			ClaimQueue.Enqueue(claim);
		}

		public Queue<Claim> GetQueue()
		{
			return ClaimQueue;
		}

		public void HandleClaim()
		{
			ClaimQueue.Dequeue();
		}

		public bool ValidityCheck(DateTime claim, DateTime accident)
		{
			if ((claim - accident).TotalDays <= 30)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
