using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.Entities
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Estatus Estatus { get; set; }

        // Relationships
        public Guid? IdSupplier { get; set; }
        public Supplier Supplier { get; set; }

        public Guid? IdPurchaseOrder { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public Guid? IdUnitOfMeasurement { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }


    }
}
