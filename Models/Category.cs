﻿using System;
using System.Collections.Generic;

namespace ActorSakilaReboot.Models
{
    public partial class Category
    {
        public Category()
        {
            FilmCategory = new HashSet<FilmCategory>();
        }

        public byte CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FilmCategory> FilmCategory { get; set; }
    }
}
