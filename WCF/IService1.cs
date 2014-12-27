﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Base.Contracts;
using System.ServiceModel.Web;

namespace WCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IService1
	{
		[OperationContract]
		[WebGet(UriTemplate = "customers/{skip}/{take}")]
		List<CustomerContract> GetCustomers(string skip, string take);

		[OperationContract]
		[WebGet(UriTemplate = "customers/{id}")]
		CustomerContract GetCustomerByID(string id);


		[OperationContract]
		[WebInvoke(UriTemplate = "orders/{customerid}")]
		List<OrderContract> GetOrdersByCustomer(string CustomerID);

		// TODO: Add your service operations here
	}
}
