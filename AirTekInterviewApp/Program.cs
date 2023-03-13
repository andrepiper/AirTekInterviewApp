using AirTek.Data.Models;
using AirTek.Services;
using AirTek.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

public class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting AirTek Console App");

        var serviceProvider = new ServiceCollection()
                        .AddTransient<IJsonFileReader<Dictionary<string,Order>>, JsonFileReader<Dictionary<string, Order>>>()
                        .AddTransient<IJsonFileReader<List<Flight>>, JsonFileReader<List<Flight>>>()
                        .AddTransient<IGenericServices, SpeedyAirServices>()
                        .BuildServiceProvider();

        //init service providers
        var speedyAirLyService = serviceProvider.GetRequiredService<IGenericServices>();
        var listOfOrdersUtil = serviceProvider.GetRequiredService<IJsonFileReader<Dictionary<string, Order>>>();
        var listOfFlightsUtil = serviceProvider.GetRequiredService<IJsonFileReader<List<Flight>>>();

        //wire up props
        var flights = await listOfFlightsUtil.Read("coding-assigment-flights.json");
        var ordersDic = await listOfOrdersUtil.Read("coding-assigment-orders.json");
        var orders = ordersDic.Select(predicate => new Order
        {
            OrderNo = predicate.Key,
            Destination = predicate.Value.Destination
        })
        .OrderBy(order => order.OrderNo)
        .ToList<Order>();

        //process flights, orders and schedule
        //user story 1
        await speedyAirLyService.PrintFlightSchedule(flights);

        //user story 2
        await speedyAirLyService.PrintOrderFlightSchedule(flights, orders, 20);

        Console.WriteLine("Ending AirTek Console, Press Enter");
        Console.ReadLine();
    }
}

