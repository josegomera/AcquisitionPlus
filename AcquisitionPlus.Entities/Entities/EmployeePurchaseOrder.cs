using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.Entities
{
    public class EmployeePurchaseOrder
    {
        public Guid? IdEmployee { get; set; }
        public Employee Employee { get; set; }

        public Guid? IdPurchaseOrder { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}
