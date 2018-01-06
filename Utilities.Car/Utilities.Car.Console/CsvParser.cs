using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Linq;
using Utilities.Car.Console.Models.Csv;

namespace Utilities.Car.Console
{
    public static class CsvParser
    {
        private const string SectionHeaderPrefix = "## ";

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

        public static IEnumerable<TItem> ParseListSection<TItem>(string sectionName, IEnumerable<IEnumerable<string>> data)
            where TItem : new()
        {
            var fullName = SectionHeaderPrefix + sectionName;
            var dataList = data.ToList();
            var sectionHeaderIndex = dataList.FindIndex(row => row.FirstOrDefault()?.Equals(fullName) ?? false) + 1;
            var sectionStartIndex = sectionHeaderIndex + 1;

            var header = dataList[sectionHeaderIndex].ToArray();
            var items = dataList.Skip(sectionStartIndex)
                .TakeWhile(row => !row.FirstOrDefault()?.StartsWith(SectionHeaderPrefix) ?? false)
                .Select(row => row.ToArray());

            return items.Select(item => CreateCsvModel<TItem>(header, item));
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
