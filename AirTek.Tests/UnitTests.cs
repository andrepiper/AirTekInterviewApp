using AirTek.Data.Models;
using AirTek.Utils;

namespace AirTek.Tests
{
    public class UnitTests
    {
        [Fact]
        public async Task TestJsonOrderFile()
        {
            var jsonReader = new JsonFileReader<Dictionary<string, Order>>();
            var ordersDic = await jsonReader.Read("coding-assigment-orders.json");
            var orders = ordersDic.Select(predicate => new Order
            {
                OrderNo = predicate.Key,
                Destination = predicate.Value.Destination
            })
            .OrderBy(order => order.OrderNo)
            .ToList<Order>();
            Assert.NotEmpty(orders);
        }

        [Fact]
        public async Task TestJsonFlightFile()
        {
            var jsonReader = new JsonFileReader<List<Flight>>();
            var flights = await jsonReader.Read("coding-assigment-flights.json");
            Assert.NotEmpty(flights);
        }
    }
}