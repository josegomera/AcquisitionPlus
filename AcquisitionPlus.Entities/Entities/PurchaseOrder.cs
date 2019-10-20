using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.Entities
{
    public class PurchaseOrder
    {
        public Guid Id { get; protected set; }
        public string NoOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
        public decimal UnitCost { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Estatus Estatus { get; set; }

        //Relationship
        public ICollection<Product> Products { get; set; }
        public ICollection<EmployeePurchaseOrder> employeePurchaseOrders { get; set; }
    }
}
