using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var path = @"C:\Users\sergeypuzyrny\Source\Repos\Utilities\Utilities.Car\Utilities.Car.Console\vehicle-1-sync.csv";
            var fields = await CsvParser.ParseFileAsync(path);
            System.Console.WriteLine(ToString(fields));
        }

        public static string ToString<TItem>(IEnumerable<IEnumerable<TItem>> items)
        {
            return string.Join(Environment.NewLine, items.Select(line => string.Join(" - ", line)));
        }


    }
}
