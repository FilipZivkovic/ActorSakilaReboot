using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActorSakilaReboot.Models
{
    public class ActorIndexData
    {
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<FilmActor> FilmActors { get; set; }
        public IEnumerable<Film> Films { get; set; }
        public IEnumerable<string> Title { get; set; }
    }
}