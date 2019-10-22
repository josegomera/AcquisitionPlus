using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.DAL.SQL;
using AcquisitionPlus.Entities.Entities;
using AcquisitionPlus.Persistence.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Persistence.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(AcquisitionPlusDbContext context) : base(context)
        {
        }

        public AcquisitionPlusDbContext AcquisitionPlusContext
        {
            get { return context; }
        }

        public void AddItemsPurchaseOrders(ICollection<Item> items, Guid Idproduct, Guid IdpurchaseOrder)
        {
            //var prod = Get(Idproduct).Product;
            foreach (var item in items)
            {
                item.Id = Guid.NewGuid();
               // item.Description = prod.Description;
                item.IdPurchaseOrder = IdpurchaseOrder;
                item.IdProduct = Idproduct;
                Add(item);
            }
        }
    }
}
