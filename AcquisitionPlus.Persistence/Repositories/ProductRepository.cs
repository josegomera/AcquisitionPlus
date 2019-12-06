using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.DAL.SQL;
using AcquisitionPlus.Entities.Entities;
using AcquisitionPlus.Persistence.Generics;

namespace AcquisitionPlus.Persistence.Repositories
{
   public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AcquisitionPlusDbContext context) : base(context)
        {
        }

        public AcquisitionPlusDbContext AcquisitionPlusContext
        {
            get { return context; }
        }

        public void Update(Product product)
        {
            var Actproduct = Get(product.Id);
            Actproduct.Description = product.Description;
            Actproduct.Brand = product.Brand;
            Actproduct.Status = product.Status;
            Actproduct.Stock = product.Stock;
            Actproduct.UnitCost = product.UnitCost;
            Actproduct.IdSupplier = product.IdSupplier;
            Actproduct.IdUnitOfMeasurement = product.IdUnitOfMeasurement;
            Actproduct.UpdateDate = product.UpdateDate;
        }
    }
}
