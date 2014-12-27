using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Contracts;
using Base.DB;

namespace Base.DAL
{
	public class CustomerService
	{
		public CustomerContract GetByID(string id)
		{
			CustomerContract customer = null;
			using (var db = new NorthwindDataContext())
			{
				var entity = db.Customers.Where(c => string.Equals(c.CustomerID, id)).FirstOrDefault<Customer>();
				if (entity != null)
					ConvertDBToContract(ref entity, ref customer);
			}
			return customer;
		}

		public List<CustomerContract> GetCustomers(int skip = 0, int take = -1)
		{
			List<CustomerContract> customers = null;
			using (var db = new NorthwindDataContext())
			{
				var query = db.Customers.Skip(skip);
				if (take > -1)
					query = query.Take(take);
				var entities = query.ToList<Customer>();
				customers = ConvertDBToContract(ref entities);
			}
			return customers;
		}

		private void ConvertDBToContract(ref Customer entity, ref CustomerContract customer)
		{
			customer = new CustomerContract
			{
				Address = entity.Address,
				City = entity.City,
				CompanyName = entity.CompanyName,
				ContactName = entity.ContactName,
				ContactTitle = entity.ContactTitle,
				Country = entity.Country,
				CustomerID = entity.CustomerID,
				Fax = entity.Fax,
				OrderIDs = entity.Orders.Select(o => o.OrderID).ToList<int>(),
				Phone = entity.Phone,
				PostalCode = entity.PostalCode,
				Region = entity.Region
			};
		}

		private List<CustomerContract> ConvertDBToContract(ref List<Customer> entities)
		{
			List<CustomerContract> customers = null;

			if (entities.Count > 0)
			{
				customers = new List<CustomerContract>();
				entities.ForEach(entity =>
				{
					customers.Add(new CustomerContract
					{
						Address = entity.Address,
						City = entity.City,
						CompanyName = entity.CompanyName,
						ContactName = entity.ContactName,
						ContactTitle = entity.ContactTitle,
						Country = entity.Country,
						CustomerID = entity.CustomerID,
						Fax = entity.Fax,
						OrderIDs = entity.Orders.Select(o => o.OrderID).ToList<int>(),
						Phone = entity.Phone,
						PostalCode = entity.PostalCode,
						Region = entity.Region
					});
				});
			}
			return customers;
		}
	}
}
