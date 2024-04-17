using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActorRepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorRepositoryLib.Tests
{
    [TestClass()]
    public class ActorRepositoryTests
    {
        public ActorRepository actorRepository = new ActorRepository();

        [TestMethod()]

        public void GetActorTest()
        {
            Assert.AreEqual(actorRepository.GetActors().Count(), 3);

            List<Actor> actorsWithHarun = actorRepository.GetActors("Harun");
            Assert.AreEqual(1, actorsWithHarun.Count);

            List<Actor> actorsWithHarunSorted = actorRepository.GetActors(sortby: "name");
            Assert.AreEqual("Gabriel", actorsWithHarunSorted[0].Name);
        }

        [TestMethod()]

        public void AddActorsTest()
        {
            int firstCount = actorRepository .GetActors().Count();
            actorRepository.AddActor(new Actor { Name = "Carl", BirthYear = 1980, Rating = 4 });
            Assert.AreEqual(actorRepository.GetActors().Count(), firstCount +1);
        }

        [TestMethod()]

        public void DeleteActorTest()
        {
            int firstCount = actorRepository.GetActors().Count();
            actorRepository.DeleteActor(1);
            Assert.AreEqual(actorRepository.GetActors().Count, firstCount - 1);

        }

        [TestMethod()]
        public void UpdateActorTest()
        {
            Actor actor = new Actor() { Id = 2, Name = "New Actor", BirthYear = 1950, Rating = 2 };
            actorRepository.UpdateActor(2, actor);
            Assert.AreEqual(actorRepository.GetActor(2).Name, actor.Name);
            Assert.AreEqual(actorRepository.GetActor(2).BirthYear, actor.BirthYear);
            Assert.AreEqual(actorRepository.GetActor(2).Rating, actor.Rating);

        }
       
    }
}