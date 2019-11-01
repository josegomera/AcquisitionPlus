using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public Guid IdPurchaseOrder { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public Guid IdProduct { get; set; }
        public Product Product { get; set; }
    }
}
