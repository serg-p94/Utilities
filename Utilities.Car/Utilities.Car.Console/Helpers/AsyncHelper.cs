using System;
using System.Threading.Tasks;

namespace Utilities.Car.Console
{
    public static class AsyncHelper
    {
        public static async Task ExecuteAsync(this Action action) => await Task.Run(action);

        public static async Task<TResult> ExecuteAsync<TResult>(this Func<TResult> func) => await Task.Run(func);
    }
}
