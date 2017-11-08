using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.BierShop.Model;
using Ploeh.AutoFixture;
using FluentAssertions;

namespace ppedv.BierShop.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_Can_Create_Instance()
        {
            new EfContext();
        }

        [TestMethod]
        public void EfContext_Can_Create_Database()
        {
            using(var context = new EfContext())
            {
                if (context.Database.Exists())
                    context.Database.Delete();

                Assert.IsFalse(context.Database.Exists());
                context.Database.Create();
                Assert.IsTrue(context.Database.Exists());
            }
        }

        [TestMethod]
        public void EfContext_Can_CRUD_Beer()
        {
            var beer = new Beer()
            {
                Name = "TestBeer",
                Alc = 4.9f,
                IsBock = false,
                Fermentation = Fermentation.low,
                Type = BeerType.Kölsch
            };

            using (var context = new EfContext())
            {
                if (!context.Database.Exists())
                    context.Database.Create();
            }

            //Insert
            using (var context = new EfContext())
            {
                context.Beer.Add(beer);
                context.SaveChanges();
            }

            //Check Insert
            var newName = "newName_" + Guid.NewGuid();
            using (var context = new EfContext())
            {
                var loaded = context.Beer.Find(beer.Id);

                Assert.IsNotNull(loaded);
                Assert.AreEqual(loaded.Name, beer.Name);
                
                loaded.Name = newName;
                context.SaveChanges();
            }

            //Check Update
            using (var context = new EfContext())
            {
                var loaded = context.Beer.Find(beer.Id);

                Assert.IsNotNull(loaded);
                Assert.AreEqual(loaded.Name, newName);

                context.Beer.Remove(loaded);
                context.SaveChanges();
            }

            //Check delete
            using (var context = new EfContext())
            {
                var loaded = context.Beer.Find(beer.Id);

                Assert.IsNull(loaded);
            }
        }


        [TestMethod]
        public void EfContext_Can_CRUD_Brewery()
        {
            var fix = new Fixture();
            var brewery = fix.Build<Brewery>().Without(x=>x.Beers).Create();

            brewery.Name.Should().NotBeEmpty();


            //Insert
            using (var context = new EfContext())
            {
                context.Brewery.Add(brewery);
                context.SaveChanges();
            }

            //Check Insert + Update
            var newName = "newName_" + Guid.NewGuid();
            using (var context = new EfContext())
            {
                var loaded = context.Brewery.Find(brewery.Id);

                loaded.Should().NotBeNull();
                loaded.ShouldBeEquivalentTo<Brewery>(brewery, o=>o.Excluding(x=>x.Id));

                loaded.Name = newName;
                context.SaveChanges();
            }

            //Check Update + Remove
            using (var context = new EfContext())
            {
                var loaded = context.Brewery.Find(brewery.Id);

                loaded.Should().NotBeNull();
                loaded.Name.Should().Be(newName);

                context.Brewery.Remove(loaded);
                context.SaveChanges();
            }

            //Check delete
            using (var context = new EfContext())
            {
                var loaded = context.Brewery.Find(brewery.Id);

                loaded.Should().BeNull();
            }
        }
    }
}
