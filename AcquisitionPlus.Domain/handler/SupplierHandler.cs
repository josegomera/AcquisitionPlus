using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.Entities.DTO;
using AcquisitionPlus.Entities.Entities;
using System;

namespace AcquisitionPlus.Domain.handler
{
    public class SupplierHandler : ISupplierRepositoryHandler
    {

        private readonly IUnitOfWork _unitOfWork;

        public SupplierHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Execute(AddSupplier_ProductsDTO addSupplier_ProductsDTO)
        {
            //Create a Supplier
            addSupplier_ProductsDTO.Supplier.Id = Guid.NewGuid();
            addSupplier_ProductsDTO.Supplier.Status = Status.Active;
            addSupplier_ProductsDTO.Supplier.CreationDate = DateTime.UtcNow.AddMinutes(-240);
            _unitOfWork.Supplier.Add(addSupplier_ProductsDTO.Supplier);

            //Create Product
            addSupplier_ProductsDTO.Product.Id= Guid.NewGuid();
            addSupplier_ProductsDTO.Product.Status = Status.Active;
            addSupplier_ProductsDTO.Product.CreationDate = DateTime.UtcNow.AddMinutes(-240);
            addSupplier_ProductsDTO.Product.IdSupplier = addSupplier_ProductsDTO.Supplier.Id;
            _unitOfWork.Product.Add(addSupplier_ProductsDTO.Product);
        }
    }
}
