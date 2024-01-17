using SkiServiceModels.BSON.DTOs.Request;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var state = new UpdateState();
            Console.Write($"Der state: {state.IsDeleted}");
        }
    }
}
