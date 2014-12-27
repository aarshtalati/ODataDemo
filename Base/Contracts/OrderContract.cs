using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Base.Contracts
{
	[DataContract]
	public partial class OrderContract
	{
		[DataMember]
		public int OrderID { get; set; }
		[DataMember]
		public Nullable<DateTime> OrderDate { get; set; }
		[DataMember]
		public Nullable<DateTime> RequiredDate { get; set; }
		[DataMember]
		public Nullable<DateTime> ShippedDate { get; set; }
		[DataMember]
		public Nullable<decimal> Freight { get; set; }
		[DataMember]
		public string ShipName { get; set; }
		[DataMember]
		public string ShipAddress { get; set; }
		[DataMember]
		public string ShipCity { get; set; }
		[DataMember]
		public string ShipRegion { get; set; }
		[DataMember]
		public string ShipPostalCode { get; set; }
		[DataMember]
		public string ShipCountry { get; set; }

		[DataMember]
		public string CustomerID { get; set; }
		[DataMember]
		public int EmployeeID { get; set; }
		[DataMember]
		public int ShipperID { get; set; }
	}
}
