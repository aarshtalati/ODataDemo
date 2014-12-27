using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoxClient
{
	public class MiniCustomerContract
	{
		public string CustomerID { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string ContactTitle { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
	}
}