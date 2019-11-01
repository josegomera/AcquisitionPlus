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

        public AcquisitionPlusDbContext AcquisitionPlusContext
        {
            get { return context; }
        }

        public void Update(UnitOfMeasurement unitOfMeasurement)
        {
            var ActunitOfMeasurement = Get(unitOfMeasurement.Id);
            ActunitOfMeasurement.Description = unitOfMeasurement.Description;
            ActunitOfMeasurement.UpdateDate = unitOfMeasurement.UpdateDate;
            ActunitOfMeasurement.Status = unitOfMeasurement.Status;
        }
    }
}
