using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_02_Claim;
using System.Collections.Generic;

namespace Challenge_02_Claim_Testproject
{
	[TestClass]
	public class UnitTest1
	{
		ClaimRepository claimRepo_ = new ClaimRepository();
		Queue<Claim> ClaimQueue = new Queue<Claim>();
		DateTime claimDate = new DateTime();
		DateTime accidentDate = new DateTime();

		[TestMethod]
		public void TestMethod1()
		{
			//There is only one method in my ClaimRepository class worth testing here.
			claimDate = DateTime.Now;
			accidentDate = DateTime.Now.AddDays(-15);
			Assert.IsTrue(claimRepo_.ValidityCheck(claimDate, accidentDate));			
		}

		[TestMethod]
		public void TestMethod2()
		{
			claimDate = DateTime.Now;
			accidentDate = DateTime.Now.AddDays(-35);
			Assert.IsFalse(claimRepo_.ValidityCheck(claimDate, accidentDate));
		}
	}
}
