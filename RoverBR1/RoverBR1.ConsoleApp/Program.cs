using System;

namespace RoverBR1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rover = new Rover();

            while (true)
            {

                Console.WriteLine(value: "Enter starting X coordinate. Please only use integers.");
                Console.Write(value: "> ");
                rover.Convert_StartX_To_Integer();

                Console.WriteLine(value: "Enter final X coordinate. Please only use integers.");
                Console.Write(value: "> ");
                rover.Convert_EndX_To_Integer();

                Console.WriteLine(value: $"({rover.Coordinates.StartX},{rover.Coordinates.EndX}");

                int DifferenceX;
                if (rover.Coordinates.StartX > rover.Coordinates.EndX)
                    {
                        DifferenceX = rover.Coordinates.StartX - rover.Coordinates.EndX;
                    }

                if (rover.Coordinates.StartX < rover.Coordinates.EndX)
                    {
                        DifferenceX = rover.Coordinates.EndX - rover.Coordinates.StartX;
                    }

                else
                    {
                        DifferenceX = 0;
                    }
                DifferenceX = Math.Abs(DifferenceX);
                
                Console.WriteLine("Move {0} steps.", DifferenceX);
            }
            

        }
    }
}
