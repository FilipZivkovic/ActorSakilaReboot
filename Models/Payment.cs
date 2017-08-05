using System;
using System.Collections.Generic;

namespace ActorSakilaReboot.Models
{
    public partial class Payment
    {
        public ushort PaymentId { get; set; }
        public decimal Amount { get; set; }
        public ushort CustomerId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? RentalId { get; set; }
        public byte StaffId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Rental Rental { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
