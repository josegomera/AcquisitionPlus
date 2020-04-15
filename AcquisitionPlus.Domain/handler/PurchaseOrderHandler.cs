using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.Business.Interfaces.Services;
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

        public dynamic Contabilize(AsientosDTO data, IPostEntriesService postEntriesService)
        {
            var accountingEntryDebit = new
            {
                data.description,
                auxiliaryAccountId = 8,
                account = "80",
                movementType = 1,
                period = DateTime.UtcNow.AddMinutes(-240),
                data.amount,
                currencyTypeId = 1
            };


            var accountingEntryCredit = new
            {
                data.description,
                auxiliaryAccountId = 8,
                account = "4",
                movementType = 1,
                period = DateTime.UtcNow.AddMinutes(-240),
                data.amount,
                currencyTypeId = 1
            };


            var Json = new
            {
                accountingEntryDebit,
                accountingEntryCredit
            };

            var result = postEntriesService.PostEntries(Json);

            _unitOfWork.PurchaseOrder.desactivatePurchases(data.purchaseOrders);

            _unitOfWork.Complete();

            return result;
        }

        /*{
			"accountingEntryDebit": {
				"description": "Pago de Nomina abri; 2019",
				"auxiliaryAccountId": 7,
				"account": "80",
				"movementType": 1,
				"period": "2019-12-01T04:22:45.253Z",
				"amount": 80000,
				"currencyTypeId": 1
		  },
		 "accountingEntryCredit": {
				"description": "Pago de Nomina abri 2019",
				"auxiliaryAccountId": 7,
				"account": "4",
				"movementType": 1,
				"period": "2019-12-01T04:22:45.253Z",
				"amount": 80000,
				"currencyTypeId": 1
			}	
		}*/

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
