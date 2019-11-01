using AcquisitionPlus.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IPurchaseHandler
    {
        void AddPurchaseOrder(AddPurchaseOrderDTO addPurchaseOrder);
    }
}
