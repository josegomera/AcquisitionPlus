using AcquisitionPlus.Entities.Entities;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        void Update(Product product);
    }
}
