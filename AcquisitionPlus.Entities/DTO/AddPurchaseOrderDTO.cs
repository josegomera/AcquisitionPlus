using AcquisitionPlus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.DTO
{
    public class AddPurchaseOrderDTO
    {
        public PurchaseOrder PurchaseOrder { get; set; }

        
        public Employee Employee { get; set; }
    }
}
