using ppedv.BierShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BierShop.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Beer> Beer { get; set; }
        public DbSet<Brewery> Brewery { get; set; }

        public EfContext(string conStringOrName) : base(conStringOrName)
        { }

        public EfContext() : this("Server=.;Database=BeerShop;Trusted_Connection=true")
        { }
    }
}
