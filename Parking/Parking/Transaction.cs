using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    class Transaction
    {
        public string ID { get; set; }
        public DateTime Payment_time { get; set; }
        public decimal Cost { get; set; }
        public Transaction (string id, DateTime dt, decimal c)
        {
            ID = id;
            Payment_time = dt;
            Cost = c;
        }

        public override string ToString()
        {
            return $"Transaction: ID: {ID} Payment time: {Payment_time} Cost: {Cost}";
        }
    }
}
