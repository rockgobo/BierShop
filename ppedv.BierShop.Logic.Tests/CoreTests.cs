using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.BierShop.Model.Contracts;
using ppedv.BierShop.Model;
using System.Linq;
using ppedv.BierShop.Model.Exceptions;

namespace ppedv.BierShop.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetAvgAlkOfAllBockBeers_3_Beers()
        {
            var core = new Core(new TestRepository());

            var result = core.GetAvgAlkOfAllBockBeers();

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Core_GetAvgAlkOfAllBockBeers_3_Beers_Moc()
        {
            var mock = new Mock<IRepository>();
            var b1 = new Beer() { IsBock = true, Alc = 6 };
            var b2 = new Beer() { IsBock = true, Alc = 2 };
            var b3 = new Beer() { IsBock = false, Alc = 6 };

            var data = new[] { b1, b2, b3 }.AsQueryable().Cast<Beer>();

            mock.Setup(x => x.Query<Beer>()).Returns(() => { return data; });
            var core = new Core(mock.Object);

            var result = core.GetAvgAlkOfAllBockBeers();

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Core_GetAvgAlkOfAllBockBeers_1_Beer()
        {
            var mock = new Mock<IRepository>();
            var b1 = new Beer() { IsBock = true, Alc = 6 };

            var data = new[] { b1 }.AsQueryable().Cast<Beer>();

            mock.Setup(x => x.Query<Beer>()).Returns(() => { return data; });
            var core = new Core(mock.Object);

            var result = core.GetAvgAlkOfAllBockBeers();

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Core_GetAvgAlkOfAllBockBeers_0_Beers_NoBeerException()
        {
            var mock = new Mock<IRepository>();
            
            var core = new Core(mock.Object);
            
            Assert.ThrowsException<NoBeerException>(() => core.GetAvgAlkOfAllBockBeers());
        }
    }
}
