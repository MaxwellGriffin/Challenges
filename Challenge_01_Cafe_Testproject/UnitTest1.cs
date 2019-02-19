using System;
using Challenge_01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_01_Cafe_Testproject
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			MenuItemRepository menuItemRepo = new MenuItemRepository();
			MenuItem testItem = new MenuItem();
			testItem.Name = "Big Mac";
			testItem.Description = "very tasty";
			testItem.Ingredients = "Patty, Bun, Lettuce, Pickle";
			testItem.Price = 1.29;
			menuItemRepo.AddItem(testItem);

			Assert.AreEqual(1, menuItemRepo.Get().Count);
			Assert.AreEqual("Big Mac", menuItemRepo.Get()[0].Name);
			
			menuItemRepo.DeleteItem(0);

			Assert.AreEqual(0, menuItemRepo.Get().Count);
		}
	}
}
