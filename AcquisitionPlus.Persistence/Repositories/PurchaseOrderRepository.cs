using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.DAL.SQL;
using AcquisitionPlus.Entities.Entities;
using AcquisitionPlus.Persistence.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcquisitionPlus.Persistence.Repositories
{
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(AcquisitionPlusDbContext context) : base(context)
        {
        }

        public AcquisitionPlusDbContext AcquisitionPlusContext
        {
            get { return context; }
        }

        public void desactivatePurchases(List<PurchaseOrder> purchaseOrders)
        {
            foreach (var purchaseOrder in purchaseOrders)
            {
                var purchaseToUpdate = AcquisitionPlusContext.PurchaseOrders.FirstOrDefault(p => p.Id == purchaseOrder.Id);
                purchaseToUpdate.Status = Status.Inactive;
                purchaseToUpdate.UpdateDate = DateTime.Now;
            }
        }
    }
}
