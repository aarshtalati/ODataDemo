using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using EF;

namespace WebApiClient.Controllers
{
	public class CustomersController : ApiController
	{
		NorthwindEntities context = new NorthwindEntities();

		// GET: api/Customers
		[EnableQuery]
		public IQueryable<Customer> Get()
		{
			context.Configuration.ProxyCreationEnabled = false;
			return context.Customers;//.AsNoTracking();
		}

		// GET: api/Customers/5
		public string Get(int id)
		{
			context.Configuration.ProxyCreationEnabled = false;
			return "value";
		}

		// POST: api/Customers
		public void Post([FromBody]string value)
		{
		}

		// PUT: api/Customers/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Customers/5
		public void Delete(int id)
		{
		}
	}
}
