using AcquisitionPlus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        void AddItemsPurchaseOrders(ICollection<Item> items, Guid Idproduct, Guid IdpurchaseOrder);
    }
}
