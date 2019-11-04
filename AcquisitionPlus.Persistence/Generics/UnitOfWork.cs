using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.DAL.SQL;
using AcquisitionPlus.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Persistence.Generics
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly AcquisitionPlusDbContext _context;

        public UnitOfWork(AcquisitionPlusDbContext context)
        {
            _context = context;

            Department = new DepartmentRepository(_context);
            Employee = new EmployeeRepository(_context);
            Product = new ProductRepository(_context); 
            PurchaseOrder = new PurchaseOrderRepository(_context);
            Supplier = new SupplierRepository(_context);
            UnitOfMeasurement = new  UnitOfMeasurementRepository(_context);
        }
        public IDepartmentRepository Department { get; private set; }

        public IEmployeeRepository Employee { get; private set; }

        public IProductRepository Product { get; private set; }

        public IPurchaseOrderRepository PurchaseOrder { get; private set; }

        public ISupplierRepository Supplier { get; private set; }

        public IUnitOfMeasurementRepository UnitOfMeasurement { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
