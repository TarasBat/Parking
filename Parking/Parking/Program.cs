using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking(10, 0, 2);
            parking = Parking.getInstance("Hotel parking");
            parking = new Parking(10, 0, 2);

            parking.Add_vehicle(new Car("BC2133AT", 2000));
            parking.Add_vehicle(new Bus("BC5233AC", 2400));
            parking.Add_vehicle(new Motorcycle("AA2133AT", 2500));
            parking.Add_vehicle(new Freight("BC8733AT", 2800));
           


            parking.Display_all_vehicle();
            parking.Refill_balance_of_vehicle("BC2133AT", 1000000m);
            parking.Remove_vehicle("BC8733AT");
            parking.Display_all_vehicle();
            Console.WriteLine("μiρφό {0}", parking.Get_count_parking_spaces());
                                   

            (new System.Threading.Thread(delegate () {
                parking.Start_work();
            })).Start();

            Thread.Sleep(6);
            Console.WriteLine("lalalallalalalalallalalal");

            
            parking.Display_transaction();
   
            

            


            Console.ReadKey();
        }
    }
}
