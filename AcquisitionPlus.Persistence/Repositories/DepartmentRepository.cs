using System.Threading.Tasks;
using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.DAL.SQL;
using AcquisitionPlus.Entities.Entities;
using AcquisitionPlus.Persistence.Generics;

namespace AcquisitionPlus.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AcquisitionPlusDbContext context) : base(context)
        {
        }

        public AcquisitionPlusDbContext AcquisitionPlusContext
        { 
            get { return context; }
        }

        public void Update(Department department)
        {
            var ActDepartment = Get(department.Id);
            ActDepartment.Name = department.Name;
            ActDepartment.Status = department.Status;
            ActDepartment.UpdateDate = department.UpdateDate;
        }
    }
}
