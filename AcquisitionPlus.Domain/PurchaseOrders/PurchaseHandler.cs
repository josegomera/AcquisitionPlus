using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.Entities.DTO;
using AcquisitionPlus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Domain.PurchaseOrders
{
    public class PurchaseHandler : IPurchaseHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddPurchaseOrder(AddPurchaseOrderDTO addPurchaseOrder)
        {
            //Create PurchaseOrder
            addPurchaseOrder.PurchaseOrder.Id = Guid.NewGuid();
            addPurchaseOrder.PurchaseOrder.OrderDate = DateTime.UtcNow.AddMinutes(-240);
            addPurchaseOrder.PurchaseOrder.CreationDate = DateTime.UtcNow.AddMinutes(-240);
            addPurchaseOrder.PurchaseOrder.Status = Status.Active;

            var employee = _unitOfWork.Employee.Get(addPurchaseOrder.PurchaseOrder.IdEmployee);

            addPurchaseOrder.PurchaseOrder.IdEmployee = employee.Id;
            _unitOfWork.PurchaseOrder.Add(addPurchaseOrder.PurchaseOrder);
        }
    }
}
