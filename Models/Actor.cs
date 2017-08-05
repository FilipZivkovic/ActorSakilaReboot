using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActorSakilaReboot.Models
{
    public partial class Actor
    {
       public Actor()
        {
            FilmActor = new HashSet<FilmActor>();
        }

        public ushort ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<FilmActor> FilmActor { get; set; }

        public static explicit operator ushort(Actor v)
        {
            throw new NotImplementedException();
        }
    }
}
