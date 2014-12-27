using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Contracts;
using Base.DB;

namespace Base.DAL
{
	public class OrderService
	{
		public List<OrderContract> GetOrdersByCustomer(string id)
		{
			List<OrderContract> orders = null;
			using (var db = new NorthwindDataContext())
			{
				var query = db.Orders.Where(o => string.Equals(o.CustomerID, id));
				var entities = query.ToList<Order>();
				orders = ConvertDBToContract(ref entities);
			}
			return orders;
		}

		private List<OrderContract> ConvertDBToContract(ref List<Order> entities)
		{
			List<OrderContract> orders = null;
			if (entities.Count > 0)
			{
				orders = new List<OrderContract>();
				entities.ForEach(entity =>
				{
					orders.Add(new OrderContract
					{
						CustomerID = entity.CustomerID,
						EmployeeID = entity.EmployeeID.HasValue ? entity.EmployeeID.Value : -1,
						Freight = entity.Freight,
						OrderDate = entity.OrderDate,
						OrderID = entity.OrderID,
						RequiredDate = entity.RequiredDate,
						ShipAddress = entity.ShipAddress,
						ShipCity = entity.ShipCity,
						ShipCountry = entity.ShipCountry,
						ShipName = entity.ShipName,
						ShippedDate = entity.ShippedDate,
						ShipperID = entity.Shipper.ShipperID,
						ShipPostalCode = entity.ShipPostalCode,
						ShipRegion = entity.ShipRegion
					});
				});
			}
			return orders;
		}
	}
}
