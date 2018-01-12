using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
            await Export(logData, "out.txt");
        }

        public static string ToString<TItem>(IEnumerable<IEnumerable<TItem>> items)
        {
            return string.Join(Environment.NewLine, items.Select(line => string.Join(" - ", line)));
        }

        public static async Task Export(IEnumerable<LogItemCsv> data, string fileName)
        {
            using (var stream = new StreamWriter(fileName))
            {
                var sb = new StringBuilder();
                data.ForEach(e => sb.AppendLine(e.ToString()));
                await stream.WriteLineAsync(sb.ToString());
                System.Console.WriteLine(sb.ToString());
            }
        }
    }
}
