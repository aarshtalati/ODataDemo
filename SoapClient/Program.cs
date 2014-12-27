using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapClient.ServiceReference1;

namespace SoapClient
{
	class Program
	{
		static void Main(string[] args)
		{
			var proxy = new ServiceReference1.Service1Client();
			foreach (var item in proxy.GetCustomers(0, 20))
			{
				Console.WriteLine(item.CustomerID);
			}
			Console.ReadKey();
		}
	}
}
