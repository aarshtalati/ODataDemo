using System.Web.Http.OData;
using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiClient.Controllers
{
	public class ProductsController : ApiController
	{
		NorthwindEntities cotnext = new NorthwindEntities();
		// GET: api/Products
		[EnableQuery]
		public IQueryable<Order> Get()
		{
			cotnext.Configuration.ProxyCreationEnabled = false;
			return cotnext.Orders;
		}

		// GET: api/Products/5
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Products
		public void Post([FromBody]string value)
		{
		}

		// PUT: api/Products/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Products/5
		public void Delete(int id)
		{
		}
	}
}
