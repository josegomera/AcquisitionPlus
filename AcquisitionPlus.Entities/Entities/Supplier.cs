using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.Entities
{
    public class Supplier
    {
        public Guid Id { get; protected set; }
        public string Identification_Rnc { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Estatus Estatus { get; set; }

        // Relationships
        public ICollection<Product> Products { get; set; }
    }
}
