using AcquisitionPlus.Entities.DTO;
using AcquisitionPlus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IPurchaseOrderHandler
    {
        void Execute(PurchaseOrder purchase);

        void Update(PurchaseOrder purchase);
    }
}
