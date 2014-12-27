using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoxClient
{
	/// <summary>
	/// Summary description for Handler1
	/// </summary>
	public class Handler1 : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			//context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");

			if (string.Compare(context.Request.HttpMethod, "GET", true) == 0)
			{
				ProcessGetRequest(context);
			}
			else if (string.Compare(context.Request.HttpMethod, "POST", true) == 0)
			{
				ProcessPostRequest(context);
			}
			else
			{
				context.Response.StatusCode = (int)System.Net.HttpStatusCode.MethodNotAllowed;
			}
		}

		private void ProcessGetRequest(HttpContext context)
		{
			context.Response.ContentType = "text/xml";
			var customerService = new Base.DAL.CustomerService();
			var data = customerService.GetCustomers(2, 8);

			var payload = new List<MiniCustomerContract>();
			data.ForEach(d =>
			{
				payload.Add(new MiniCustomerContract
				{
					CompanyName = d.CompanyName,
					ContactName = d.ContactName,
					ContactTitle = d.ContactTitle,
					Country = d.Country,
					CustomerID = d.CustomerID,
					Phone = d.Phone
				});
			});

			var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(List<MiniCustomerContract>));
			serializer.WriteObject(context.Response.OutputStream, payload);
		}

		private void ProcessPostRequest(HttpContext context)
		{
			throw new NotImplementedException();
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}