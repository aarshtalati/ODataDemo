using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Base.Contracts
{
	[DataContract]
	public partial class ProductContract
	{
		[DataMember]
		public int ProductID { get; set; }
		[DataMember]
		public string ProductName { get; set; }
		[DataMember]
		public string QuantityPerUnit { get; set; }
		[DataMember]
		public Nullable<decimal> UnitPrice { get; set; }
		[DataMember]
		public Nullable<short> UnitsInStock { get; set; }
		[DataMember]
		public Nullable<short> UnitsOnOrder { get; set; }
		[DataMember]
		public Nullable<short> ReorderLevel { get; set; }
		[DataMember]
		public bool Discontinued { get; set; }

		[DataMember]
		public int CategoryID { get; set; }
		[DataMember]
		public int SupplierID { get; set; }
	}
}
