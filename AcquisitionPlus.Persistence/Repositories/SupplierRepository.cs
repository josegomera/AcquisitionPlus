using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.DAL.SQL;
using AcquisitionPlus.Entities.Entities;
using AcquisitionPlus.Persistence.Generics;

namespace AcquisitionPlus.Persistence.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AcquisitionPlusDbContext context) : base(context)
        {
        }

        public AcquisitionPlusDbContext AcquisitionPlusContext
        {
            get { return context; }
        }

        public void Update(Supplier supplier)
        {
            var ActSupplier = Get(supplier.Id);
            ActSupplier.Identification_Rnc = supplier.Identification_Rnc;
            ActSupplier.UpdateDate = supplier.UpdateDate;
            ActSupplier.Status = supplier.Status;
            ActSupplier.Name = supplier.Name;
        }
    }
}
