using System;
using Newtonsoft.Json;

namespace Utilities.Car.Console.Models.Csv
{
    public abstract class BaseCsvModel
    {
        [JsonIgnore]
        public abstract string SectionName { get; }
    }
}
