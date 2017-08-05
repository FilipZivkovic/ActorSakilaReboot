﻿using System;
using System.Collections.Generic;

namespace ActorSakilaReboot.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Payment = new HashSet<Payment>();
            Rental = new HashSet<Rental>();
        }

        public byte StaffId { get; set; }
        public bool Active { get; set; }
        public ushort AddressId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public byte[] Picture { get; set; }
        public byte StoreId { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Rental> Rental { get; set; }
        public virtual Store StoreNavigation { get; set; }
        public virtual Address Address { get; set; }
        public virtual Store Store { get; set; }
    }
}
