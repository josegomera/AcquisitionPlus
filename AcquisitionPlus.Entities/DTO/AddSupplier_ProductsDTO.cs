using AcquisitionPlus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.DTO
{
    public class AddSupplier_ProductsDTO
    {
        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
    }
}
