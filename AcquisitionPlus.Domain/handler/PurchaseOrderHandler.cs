using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.Entities.DTO;
using AcquisitionPlus.Entities.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Domain.handler
{
    public class PurchaseOrderHandler : IPurchaseOrderHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Contabilize(JObject data)
        {
            var accountingEntryDebit = new
            {
        
            };
        }

        public void Execute(PurchaseOrder purchase)
        {
            //Create a Purchase Order
            Random ram = new Random();
            purchase.Id = Guid.NewGuid();
            purchase.NoOrder = "PO-" + ram.Next(0, 9999).ToString("D4");
            purchase.CreationDate = DateTime.UtcNow.AddMinutes(-240);
            purchase.OrderDate = DateTime.UtcNow.AddMinutes(-240);
            purchase.Status = Status.Active;
            purchase.Total = purchase.Amount * purchase.UnitCost;
            _unitOfWork.PurchaseOrder.Add(purchase);

            //Update Product Stock

            var product = _unitOfWork.Product.Get(x => x.Id == purchase.IdProduct);
            product.Stock -= purchase.Amount;
            //product.Stock = product.Stock - purchase.Amount;
            product.UpdateDate = DateTime.UtcNow.AddMinutes(-240);
            _unitOfWork.Product.Update(product);
        }

        public void Update(PurchaseOrder purchase)
        {
            var old = _unitOfWork.PurchaseOrder.Get(purchase.Id);
            old.Amount = purchase.Amount;
            old.UnitCost = purchase.UnitCost;
            old.UpdateDate = DateTime.UtcNow.AddMinutes(-240);
            old.Status = purchase.Status;
            old.Total = purchase.Amount * purchase.UnitCost;
        }
    }
}
