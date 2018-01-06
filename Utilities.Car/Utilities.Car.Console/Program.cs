using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Car.Console.Models.Csv;

namespace Utilities.Car.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(DoWork).Wait();
        }

        private static async Task DoWork()
        {
            var path = @"vehicle-1-sync.csv";
            var fields = await CsvParser.ParseFileAsync(path);
            var vehicleData = CsvParser.ParseListSection<VehicleCsv>("Vehicle", fields).ToList();
            var logData = CsvParser.ParseListSection<LogItemCsv>("Log", fields).ToList();
        }

        public static string ToString<TItem>(IEnumerable<IEnumerable<TItem>> items)
        {
            return string.Join(Environment.NewLine, items.Select(line => string.Join(" - ", line)));
        }


    }
}
