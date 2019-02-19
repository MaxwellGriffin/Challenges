using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_03_Outing;

namespace Challenge_03_Outing_Testproject
{
	[TestClass]
	public class UnitTest1
	{
		OutingRepository outingRepo = new OutingRepository();

		[TestMethod]
		public void TestMethod1()
		{
			Outing outingOne = new Outing();
			outingOne.Attendence = 50;
			outingOne.TicketPrice = 49.99;
			outingOne.ExtraCost = 25;
			outingOne.OutingType = Outing.OutingTypes.AmusementPark;
			outingRepo.SetNewOuting(outingOne);

			Outing outingTwo = new Outing();
			outingTwo.Attendence = 15;
			outingTwo.TicketPrice = 29.99;
			outingTwo.ExtraCost = 0;
			outingTwo.OutingType = Outing.OutingTypes.AmusementPark;
			outingRepo.SetNewOuting(outingTwo);

			Assert.AreEqual(2974.35, outingRepo.CostOf(Outing.OutingTypes.AmusementPark));
		}
	}
}
