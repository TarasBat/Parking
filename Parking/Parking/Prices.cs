using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    class Prices
    {
        public static decimal Fine = 1.5m; // штраф
        public static decimal PriceForCar = 2m;
        public static decimal PriceForFreight = 5m;
        public static decimal PriceForBus = 3.5m;
        public static decimal PriceForMotorcycle = 1m;
        public Prices(decimal f, decimal c, decimal fr, decimal b, decimal m)
        {
            Fine = f;
            PriceForCar = c;
            PriceForFreight = fr;
            PriceForBus = b;
            PriceForMotorcycle = m;
        }
    }
}
