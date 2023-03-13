using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek.Data.Models
{
    public class FlightOrderSchedule
    {
        public Flight Flight { get; set; }
        public List<Order> Orders { get; set; }
        public FlightOrderSchedule() {
            Orders = new List<Order>();
        }
        public void AddFlightOrders(List<Order> order,int count)
        {
            foreach(var orderItem in order)
            {
                if (Orders.Count < count)
                {
                    Orders.Add(orderItem);
                }
            }
        }
    }
}
