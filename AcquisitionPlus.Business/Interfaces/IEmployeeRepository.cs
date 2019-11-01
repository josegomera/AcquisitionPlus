using AcquisitionPlus.Entities.Entities;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        void Update(Employee employee);
    }
}
