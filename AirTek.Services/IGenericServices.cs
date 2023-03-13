using AirTek.Data.Models;

namespace AirTek.Services
{
    public interface IGenericServices
    {
        Task PrintOrderFlightSchedule(List<Flight> listOfFlights, List<Order> listOfOrders, int maxOrderAmt = 20);
        Task PrintFlightSchedule(List<Flight> listOfFlights);
    }
}