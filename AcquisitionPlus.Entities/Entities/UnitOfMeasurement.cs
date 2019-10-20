using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.Entities
{
    public class UnitOfMeasurement
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }

        // Relationships
        public ICollection<Product> Products { get; set; }
    }
}
