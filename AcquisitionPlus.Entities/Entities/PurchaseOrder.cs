using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.Entities
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }
        public string NoOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }

        public Guid IdProduct { get; set; }
        public Product Product { get; set; }

        public Guid IdEmployee { get; set; }
        public Employee Employee { get; set; }

    }
}
