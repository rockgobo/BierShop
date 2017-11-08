using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BierShop.Model
{
    public class Brewery : Entity
    {
        public string Name { get; set; }
        public string Ort { get; set; }
        public HashSet<Beer> Beers { get; set; } = new HashSet<Beer>();
    }
}
