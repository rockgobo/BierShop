using ppedv.BierShop.Data.EF;
using ppedv.BierShop.Model;
using ppedv.BierShop.Model.Contracts;
using ppedv.BierShop.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BierShop.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core() : this(new EfRepository()) { }

        public Core(IRepository repo)
        {
            Repository = repo;     
        }

        public double GetAvgAlkOfAllBockBeers()
        {
            var beers = Repository.Query<Beer>().Where(x => x.IsBock);
            if (!beers.Any()) throw new NoBeerException();
            return beers.Average(x => x.Alc);
        }
    }
}
