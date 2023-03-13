using AirTek.Data.Models;
using AirTek.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek.Services
{
    public class SpeedyAirServices : IGenericServices
    {
        public SpeedyAirServices(){
        }

        public async Task PrintFlightSchedule(List<Flight> listOfFlights)
        {
            Console.WriteLine("Printing user story - 1:");
            foreach (var flight in listOfFlights)
            {
                Console.WriteLine($"Flight: {flight.Number}, departure: {flight.Outbound}, arrival: {flight.Inbound}, day: {flight.Day}");

            }
        }

        public async Task PrintOrderFlightSchedule(List<Flight> listOfFlights, List<Order> listOfOrders, int maxOrderAmt)
        {
            listOfFlights.OrderBy(flight => flight.Number);

            var notScheduled = new List<Order>();
            var flightSchedules = new List<FlightOrderSchedule>();
            var getMaxDays = listOfFlights[listOfFlights.Count - 1].Day;

            for (int day = 1; day <= getMaxDays; day++)
            {
                foreach (Flight flight in listOfFlights)
                {
                    if (flight.Day == day)
                    {
                        var orders = listOfOrders
                            .Where(predicate => predicate.Destination.ToLower() == flight.Inbound.ToLower())
                            .ToList();

                        var temp = new FlightOrderSchedule();
                        temp.Flight = flight;
                        temp.Orders = orders.Take(maxOrderAmt).ToList();
                        //select those not in apart of the maxOrderAmt
                        var excpted = orders.Except(temp.Orders).ToList();
                        notScheduled.AddRange(excpted);
                        flightSchedules.Add(temp);
                    }
                }
            }

            //not scheduled boxes/orders
            flightSchedules.Add(new FlightOrderSchedule()
            {
                Orders = notScheduled.Distinct().ToList(),
            });

            Console.WriteLine(" ");
            Console.WriteLine("Printing user story - 2:");
            foreach (var flightOrderSchedule in flightSchedules)
            {
                foreach (var flightOrder in flightOrderSchedule.Orders)
                {
                    if (flightOrderSchedule.Flight != null)
                    {
                        Console.WriteLine($"order: {flightOrder.OrderNo}, " +
                            $"flightNumber: {flightOrderSchedule.Flight.Number}, " +
                            $"departure: {flightOrderSchedule.Flight.Outbound}, " +
                            $"arrival: {flightOrderSchedule.Flight.Inbound}, day: {flightOrderSchedule.Flight.Day}");

                    }
                    else
                    {
                        Console.WriteLine($"order: {flightOrder.OrderNo}, flightNumber: not scheduled");
                    }
                }
            }

        }
    }
}
