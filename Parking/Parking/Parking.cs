using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Parking
{
    class Parking
    {
        private static Parking instance;

        public string Name { get; private set; }

        protected Parking(string name)
        {
            this.Name = name;
        }
        public static Parking getInstance(string name)
        {
            if (instance == null)
                instance = new Parking(name);
            return instance;
        }
        ////////////////////////////////////////////////////////////
        List<Vehicle> vehicle_list = new List<Vehicle>();
        List<Transaction> transactions = new List<Transaction>(); // тут планував зберігати тразакції за останню хвилину. 
        private int number_parking_spaces;
        private decimal balance;
        private int time_interval; // періодичність оплати
        public Parking(int nps=0, decimal b=0m, int ti=0)
        {
            number_parking_spaces = nps;
            balance = b;
            time_interval = ti;
            Console.WriteLine("Немає мiсць {0}", number_parking_spaces);
        }

        public decimal Get_balance()
        {
            return balance;
        }

        public void Start_work()
        {
            using (StreamWriter sw = new StreamWriter("parking.log", false, System.Text.Encoding.Default))
            {        
                while (true)
                {
                    foreach (var v in vehicle_list)
                    {
                        transactions.Add(v.Payment());
                        sw.WriteLine(v.ToString());
                        Console.WriteLine("Налог");
                    }
                    //Thread.Sleep(955);
                }
            }
        }

        public decimal Profit_last_minute() // зароблені гроші за останню хвилину
        {
            decimal temp = 0m;
            foreach(var t in transactions)
            {
                temp += t.Cost;
            }
            return temp;
        }

        public void Refill_balance_of_vehicle(string vin, decimal sum) // поповнити баланс конкретного транспортного засобу
        {
            foreach(var v in vehicle_list)
            {
                if(v.VIN==vin)
                {                   
                    v.Balance += sum;
                }
            }
        }
               
        public void Add_vehicle(Vehicle v)
        {
            Console.WriteLine("Немає мiсць {0}", number_parking_spaces);
            if (vehicle_list.Count < number_parking_spaces)
            {
                vehicle_list.Add(v);
            }
            else
            {
                Console.WriteLine("Немає мiсць");
            }
    
        }

        public void Print_history_transaction(string path)
        {
            foreach (string lines in File.ReadLines(path))
            {
                Console.WriteLine(lines);
            }
        }

        public int Get_count_parking_spaces()
        {
            return number_parking_spaces - vehicle_list.Count;
        }

        public void Remove_vehicle(string vin)
        {            
            vehicle_list.RemoveAll(x => x.VIN == vin);
        }

        public void Display_transaction()
        {
            foreach (var t in transactions)
            {
                Console.WriteLine(t);
            }
        }

        public void Display_all_vehicle()
        {
            foreach(var v in vehicle_list)
            {
                Console.WriteLine(v);
            }
        }
    }
}
