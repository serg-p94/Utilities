using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace Utilities.Car.Console
{
    public static class CsvParser
    {
        public static async Task<IEnumerable<IEnumerable<string>>> ParseFileAsync(string name) => await AsyncHelper.ExecuteAsync(() => ParseFile(name));

        public static IEnumerable<IEnumerable<string>> ParseFile(string name)
        {
            using (var parser = new TextFieldParser(name) {TextFieldType = FieldType.Delimited})
            {
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();
                    yield return fields;
                }
            }
        }
    }
}
