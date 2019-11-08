using AcquisitionPlus.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface ISupplierRepositoryHandler
    {
        void Execute(AddSupplier_ProductsDTO addSupplier_ProductsDTO);
    }
}
