using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.Entities
{
    public class Employee
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Position { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Estatus Estatus { get; set; }

        //Relationship
        public Guid? IdDepartment { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeePurchaseOrder> employeePurchaseOrders { get; set; }
    }
}
