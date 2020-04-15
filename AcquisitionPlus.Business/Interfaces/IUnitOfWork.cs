using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IUnitOfWork
    {
        int Complete();

        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
        IProductRepository Product { get; }
        IPurchaseOrderRepository PurchaseOrder { get; }
        ISupplierRepository Supplier { get; }
        IUnitOfMeasurementRepository UnitOfMeasurement { get; }
        void Dispose();
    }
}
