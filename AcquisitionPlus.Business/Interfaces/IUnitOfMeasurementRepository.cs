using AcquisitionPlus.Entities.Entities;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IUnitOfMeasurementRepository : IBaseRepository<UnitOfMeasurement>
    {
        void Update(UnitOfMeasurement unitOfMeasurement);
    }
}
