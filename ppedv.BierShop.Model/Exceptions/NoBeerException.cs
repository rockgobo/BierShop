using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BierShop.Model.Exceptions
{
    public class NoBeerException : Exception
    {
        public bool Panic { get { return true; } } 
    }
}
