using System;
using System.Collections.Generic;

namespace ActorSakilaReboot.Models
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public ushort CityId { get; set; }
        public string City1 { get; set; }
        public ushort CountryId { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual Country Country { get; set; }
    }
}
