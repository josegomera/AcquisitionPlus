using AcquisitionPlus.Entities.Entities;
using System.Threading.Tasks;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        void Update(Department department);
    }
}
