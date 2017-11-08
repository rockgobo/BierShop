using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BierShop.Model
{
    public class Beer : Entity
    {
        public string Name { get; set; }

        public float Alc { get; set; }

        public virtual Brewery Brewery { get; set; }

        public bool IsBock { get; set; }

        public Fermentation Fermentation { get; set; }

        public BeerType Type { get; set; }
    }

    public enum BeerType
    {
        Hell,
        Weizen,
        Alt,
        Kölsch,
        APA,
        Keller,
        Waldmeister,
        Ale,
        Lager
    }

    public enum Fermentation
    {
        top, low
    }
}
