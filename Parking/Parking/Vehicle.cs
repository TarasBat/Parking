using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    abstract class Vehicle
    {
        protected decimal balance;
        protected string vin;
        public string VIN
        {
            get
            {
                return vin;
            }
            set
            { vin = value; }
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            { balance = value; }
        }
        public Vehicle(string v = "", decimal b=0)
        {
            balance = b;
            VIN = v;
        }

        public override string ToString()
        {
            return $"Balance: {balance} VIN: {VIN}";
        }

        public abstract Transaction Payment();  
        
    }

    class Car : Vehicle
    {
        public Car(string v, decimal b) : base(v, b) { }
        public override Transaction Payment()
        {
            decimal old_balance = balance;
            if(balance > Prices.PriceForCar)
            {
                balance -= Prices.PriceForCar;
            }
            else
            {
                balance -= Prices.PriceForCar * Prices.Fine;
            }
            return new Transaction(VIN, DateTime.Now, old_balance - balance);
        }
        public override string ToString()
        {
            return "Car: "+ base.ToString();
        }

        
    }
    class Freight : Vehicle
    {
        public Freight(string v, decimal b) : base(v, b) { }
        public override Transaction Payment()
        {
            decimal old_balance = balance;
            if (balance > Prices.PriceForFreight)
            {
                balance -= Prices.PriceForFreight;
            }
            else
            {
                balance -= Prices.PriceForFreight * Prices.Fine;
            }
            return new Transaction(VIN, DateTime.Now, old_balance - balance);
        }
        public override string ToString()
        {
            return "Freight: " + base.ToString();
        }
    }

    class Bus : Vehicle
    {
        public Bus(string v, decimal b) : base(v, b) { }
        public override Transaction Payment()
        {
            decimal old_balance = balance;
            if (balance > Prices.PriceForBus)
            {
                balance -= Prices.PriceForBus;
            }
            else
            {
                balance -= Prices.PriceForBus * Prices.Fine;
            }
            return new Transaction(VIN, DateTime.Now, old_balance - balance);
        }
        public override string ToString()
        {
            return "Bus: " + base.ToString();
        }
    }
    class Motorcycle : Vehicle
    {
        public Motorcycle(string v, decimal b) : base(v, b) { }
        public override Transaction Payment()
        {
            decimal old_balance = balance;
            if (balance > Prices.PriceForMotorcycle)
            {
                balance -= Prices.PriceForMotorcycle;
            }
            else
            {
                balance -= Prices.PriceForMotorcycle * Prices.Fine;
            }
            return new Transaction(VIN, DateTime.Now, old_balance - balance);
        }
        public override string ToString()
        {
            return "Motorcycle: " + base.ToString();
        }
    }
}

