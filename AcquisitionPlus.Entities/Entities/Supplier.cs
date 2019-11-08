using System;
using System.Collections.Generic;

namespace AcquisitionPlus.Entities.Entities
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Identification_Rnc { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }

        // Relationships
        public ICollection<Product> Products { get; set; }
    }
}
