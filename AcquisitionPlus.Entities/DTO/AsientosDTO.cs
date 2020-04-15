using AcquisitionPlus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.DTO
{
    public class AsientosDTO
    {
        public string description {get; set;}
        public decimal amount {get; set;}

        public List<PurchaseOrder> purchaseOrders { get; set; }
    }
}
