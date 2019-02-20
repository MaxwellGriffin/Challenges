using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_05_Greet
{
	class CustomerRepository
	{
		List<Customer> customerList = new List<Customer>();

		public List<Customer> GetCustomerList()
		{
			return customerList;
		}

		public void SetCustomerList(List<Customer> templist)
		{
			customerList = templist;
			SortList();
		}

		public void AddCustomerToList(Customer newCustomer)
		{
			customerList.Add(newCustomer);
			SortList();
		}

		private void SortList()
		{
			var sortedQuery = customerList.OrderBy(x => x.LastName);
			Customer[] customerArray = sortedQuery.ToArray();

			int i = 0;
			while (i < customerArray.Length - 1)
			{
				if (customerArray[i].LastName == customerArray[i+1].LastName)
				{
					if(string.Compare(customerArray[i].FirstName, customerArray[i+1].FirstName) > 0)
					{
						Customer temp = customerArray[i];
						customerArray[i] = customerArray[i + 1];
						customerArray[i + 1] = temp;
						i = 0;
					}
				}
				i++;
			}
			customerList = customerArray.ToList(); 
		}
	}
}
