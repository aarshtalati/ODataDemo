using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Base.DAL;

namespace PoxClient
{
	public class Service1POX : IHttpHandler
	{
		#region IHttpHandler Members

		public bool IsReusable
		{
			get { throw new NotImplementedException(); }
		}

		public void ProcessRequest(HttpContext context)
		{
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
				context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
			}
		}

		private void ProcessGetRequest(HttpContext context)
		{
			context.Response.ContentType = "text/xml";
			var customerService = new CustomerService();
			var payload = customerService.GetCustomers(2, 8);
			var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(List<Base.Contracts.CustomerContract>));
			serializer.WriteObject(context.Response.OutputStream, payload);
		}

		private void ProcessPostRequest(HttpContext context)
		{
			throw new NotImplementedException();
		}


		#endregion
	}
}
