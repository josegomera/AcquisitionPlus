using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.DAL.SQL;
using AcquisitionPlus.Entities.Entities;
using AcquisitionPlus.Persistence.Generics;

namespace AcquisitionPlus.Persistence.Repositories
{
    public class EmployeePurchaseOrderRepository : BaseRepository<EmployeePurchaseOrder>, IEmployeePurchaseOrderRepository
    {
        public EmployeePurchaseOrderRepository(AcquisitionPlusDbContext context) : base(context)
        {
        }

        public AcquisitionPlusDbContext PegasusContext
        {
            get { return context; }
        }
    }
}
