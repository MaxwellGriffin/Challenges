using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04_Badge
{
	class BadgeRepository
	{
		public Dictionary<int, Badge> badgeDictionary = new Dictionary<int, Badge>(); 

		public Dictionary<int, Badge> GetBadgeDictionary()
		{
			return badgeDictionary;
		}

		public void AddNewBadge(Badge newbadge)
		{
			badgeDictionary.Add(newbadge.BadgeID, newbadge);
		}

		public void SetBadge(Badge newbadge, int x)
		{
			badgeDictionary[x] = newbadge;
		}
	}
}
