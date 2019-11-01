using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.DAL.SQL;
using AcquisitionPlus.Entities.Entities;
using AcquisitionPlus.Persistence.Generics;

namespace AcquisitionPlus.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AcquisitionPlusDbContext context) : base(context)
        {
        }

        public AcquisitionPlusDbContext AcquisitionPlusContext
        {
            get { return context; }
        }

        public void Update(Employee employee)
        {
            var ActEmployee = Get(employee.Id);
            ActEmployee.Name = employee.Name;
            ActEmployee.LastName = employee.LastName;
            ActEmployee.IdentificationNumber = employee.IdentificationNumber;
            ActEmployee.Position = employee.Position;
            ActEmployee.TelephoneNumber = employee.TelephoneNumber;
            ActEmployee.UpdateDate = employee.UpdateDate;
            ActEmployee.Status = employee.Status;
            ActEmployee.IdDepartment = employee.IdDepartment;
        }
    }
}
