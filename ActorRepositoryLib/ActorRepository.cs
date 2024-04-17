using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ActorRepositoryLib
{
    public class ActorRepository
    {
        private int _nextId = 4;

        private List<Actor> _actors = new()
        {
            new Actor { Id = 1, Name = "Harun", BirthYear = 2002, Rating = 3},
            new Actor { Id = 2, Name = "Gabriel", BirthYear = 1995, Rating = 9},
            new Actor { Id = 3, Name = "Pall", BirthYear = 1998, Rating= 10},
        };

        public List<Actor>GetActors(string? nameStart=null, string? sortby = null, object value = null)
        {
            List<Actor> result = new List<Actor>(_actors);

            if(nameStart != null)
            {
                result = result.FindAll(a => a.Name.StartsWith(nameStart));
            }

            if (sortby != null)
            {
                switch (sortby)
                {
                    case "name":
                            result.Sort((a1,a2) => a1.Name.CompareTo(a2.Name));
                        break;
                    case "name_desc":
                        result.Sort((a1,a2) => a2.Name.CompareTo(a1.Name));
                        break;
                    case "birthYear":
                        result.Sort((a1,a2) => a1.BirthYear - a2.BirthYear);
                        break;   
                }
            }

            return result;
        }

        public Actor AddActor(Actor actor)
        {
            actor.Id = _nextId++;
            _actors.Add(actor);
            return actor;
        }

        public Actor? GetActor(int id)
        {
            return _actors.Find(a => a.Id == id);
        }

        public Actor? DeleteActor(int id)
        {
            Actor? actor = _actors.Find(a => a.Id == id);
            if(actor != null)
            {
                _actors.Remove(actor);
            }
            return actor;
        }

        public Actor? UpdateActor(int id, Actor data)
        {
            Actor? actorToUpdate = _actors.Find(a => a.Id == id);
            if (actorToUpdate != null)
            {
                actorToUpdate.Name = data.Name;
                actorToUpdate.BirthYear = data.BirthYear;
                actorToUpdate.Rating = data.Rating;
            }
            return actorToUpdate;
        }

        public override string ToString()
        {
            return string.Join(", ", _actors);
        }
    }
}