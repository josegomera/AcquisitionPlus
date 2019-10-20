using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.DAL.SQL;
using AcquisitionPlus.Entities.Entities;
using AcquisitionPlus.Persistence.Generics;

namespace AcquisitionPlus.Persistence.Repositories
{
   public class UnitOfMeasurementRepository : BaseRepository<UnitOfMeasurement>, IUnitOfMeasurementRepository
    {
        public UnitOfMeasurementRepository(AcquisitionPlusDbContext context) : base(context)
        {
        }

        public AcquisitionPlusDbContext PegasusContext
        {
            get { return context; }
        }
    }
}
