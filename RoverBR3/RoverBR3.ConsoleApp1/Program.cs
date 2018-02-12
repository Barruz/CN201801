using System;

namespace RoverBR3.ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var navigator = new Navigator();
            while (true)
            {
                Console.WriteLine(value: "> Enter starting coordinates and direction. Use the format ‘X,Y,D’, where X and Y are integers and D has one of the following values: N, S, E, W.");
                Console.Write(value: "> ");
                var coordinates = Console.ReadLine();
                navigator.GetStartCoordinates(coordinates); // Store starting coordinates in 'start' variables
                Console.WriteLine(value: "> Enter end coordinates and direction. Use the format ‘X,Y,D’, where X and Y are integers and D has one of the following values: N, S, E, W.");
                Console.Write(value: "> ");
                coordinates = Console.ReadLine();
                navigator.GetInstructions(coordinates); // Store end coordinates in 'end' variables & get instructions
                Console.WriteLine(navigator.Instructions);
            }
        }
    }
}
