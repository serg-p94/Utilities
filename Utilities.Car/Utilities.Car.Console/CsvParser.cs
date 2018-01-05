using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

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

        public static TModel CreateCsvModel<TModel>(string[] names, string[] values) where TModel : new()
        {
            var propertiesDictionary = new Dictionary<string, string>(names.Length);
            names.ForEach((i, name) => propertiesDictionary[name] = values[i]);

            var propertiesString = JsonConvert.SerializeObject(propertiesDictionary);

            return JsonConvert.DeserializeObject<TModel>(propertiesString);
        }
    }
}
