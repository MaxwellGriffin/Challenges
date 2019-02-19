using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02_Claim
{
	//public enum ClaimTypeTwo { Car, Home, Theft }
	public class Claim
	{
		public int ClaimID { get; set; }
		public char ClaimType { get; set; }
		public string Description { get; set; }
		public double Amount { get; set; }
		public DateTime DateOfAccident { get; set; }
		public DateTime DateOfClaim { get; set; }
		public bool IsValid { get; set; }

		public string TypeOfClaim()
		{
			switch (ClaimType.ToString().ToLower()[0])
			{
				case 'c':
					return "Car";
				case 'h':
					return "Home";
				case 't':
					return "Theft";
				default:
					return "ERROR";
			}
		}
		public string AccDateShort()
		{
			string date = DateOfAccident.Date.ToString();
			return date.Substring(0, date.IndexOf(" "));
		}
		public string ClaimDateShort()
		{
			string date = DateOfClaim.Date.ToString();
			return date.Substring(0, date.IndexOf(" "));
		}
	}
}
