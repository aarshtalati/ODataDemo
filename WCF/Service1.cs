using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Base.Contracts;
using Base.DAL;
using Base.DB;

namespace WCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
	public class Service1 : IService1
	{

		#region IService1 Members

		public CustomerContract GetCustomerByID(string CustomerID)
		{
			var customerService = new CustomerService();
			var c = customerService.GetByID(CustomerID);
			return c;
		}

		public List<CustomerContract> GetCustomers(string skip, string take)
		{
			var customerService = new CustomerService();
			return customerService.GetCustomers(int.Parse(skip), int.Parse(take));
		}

		public List<OrderContract> GetOrdersByCustomer(string CustomerID)
		{
			var orderService = new OrderService();
			return orderService.GetOrdersByCustomer(CustomerID);
		}
		#endregion
	}
}
