﻿using System;
using System.Collections.Generic;

namespace ActorSakilaReboot.Models
{
    public partial class Rental
    {
        public Rental()
        {
            Payment = new HashSet<Payment>();
        }

        public int RentalId { get; set; }
        public ushort CustomerId { get; set; }
        public int InventoryId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public byte StaffId { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Staff Staff { get; set; }
    }
}