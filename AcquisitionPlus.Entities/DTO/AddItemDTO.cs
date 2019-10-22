using AcquisitionPlus.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcquisitionPlus.Entities.DTO
{
    public class AddItemDTO
    {
        public ICollection<Item> Items { get; set; }

        public Guid IdProduct { get; set; }

        public Guid IdPurchaseOrder { get; set; }

    }
}
