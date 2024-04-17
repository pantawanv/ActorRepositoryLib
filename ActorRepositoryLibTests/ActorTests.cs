using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActorRepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace ActorRepositoryLib.Tests
{
    [TestClass()]
    public class ActorTests
    {
        [TestMethod()]
        public void ValidateNameTest()
        {
            Actor actor = new()
            {
                Id = 1,
                Name = "Tom Cruise",
                BirthYear = 1962,
                Rating = 9
            };

            actor.ValidateName();

            Actor actorShortName = new()

            {
                Id = 2,
                Name = "Tom",
                BirthYear = 1962,
                Rating = 7
            };
            Assert.ThrowsException<ArgumentException>(() => actorShortName.ValidateName());

            Actor actorNull = new()
            {
                Id = 5,
                Name = null,
                BirthYear = 2000,
                Rating = 7
            };
            Assert.ThrowsException<ArgumentNullException>(() => actorNull.ValidateName());

           
        }

        [TestMethod()]
        public void ValidateBirthYearTest()
        {
            Actor actor = new()
            {
                Id = 3,
                Name = "Julia Roberts",
                BirthYear = 1967,
                Rating = 10
            };
            actor.ValidateBirthYear();

            Actor actorBadBirthYear = new()
            {
                Id = 4,
                Name = "Tom Hanks",
                BirthYear = 1819,
                Rating = 11
            };
            Assert.ThrowsException<ArgumentException>(() => actorBadBirthYear.ValidateBirthYear());
        }
    }
}