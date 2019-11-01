using AcquisitionPlus.Entities.Entities;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        void Update(Supplier supplier);
    }
}
