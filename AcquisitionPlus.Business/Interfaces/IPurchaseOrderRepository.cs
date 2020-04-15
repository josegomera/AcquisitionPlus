
using AcquisitionPlus.Entities.Entities;
using System.Collections.Generic;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IPurchaseOrderRepository : IBaseRepository<PurchaseOrder>
    {
        void desactivatePurchases(List<PurchaseOrder> purchaseOrders);
    }
}
