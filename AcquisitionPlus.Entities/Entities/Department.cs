using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.Entities
{
    public class Department
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Estatus Estatus { get; set; }

        //Relationship
        public ICollection<Employee> Employees { get; set; }
    }
}
