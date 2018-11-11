using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Transactions;
using Microsoft.Extensions.Configuration;
using TflConsume.Services;

namespace TflConsume.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            try
            {
                var result = RoadService.GetRoadStatus(args[0], configuration["appId"], configuration["developerKey"]);

                Console.WriteLine($"The status of the {result.DisplayName} is as follows");
                Console.WriteLine($"Road Status is {result.StatusSeverity}");
                Console.WriteLine($"Road Status Description is {result.StatusSeverityDescription}");
                Environment.ExitCode = 0;
            }
            catch (Exception e)
            {
               Console.WriteLine($"{args[0]} is not a valid road");
                Environment.ExitCode = 1;
            }
        }
    }
}
