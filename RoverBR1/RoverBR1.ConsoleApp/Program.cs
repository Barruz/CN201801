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
                // Enter starting X coordinate
                Console.WriteLine(value: "Enter starting X coordinate. Please only use integers.");
                Console.Write(value: "> ");
                rover.Convert_StartX_To_Integer();

                // Enter starting Y coordinate
                Console.WriteLine(value: "Enter starting Y coordinate. Please only use integers.");
                Console.Write(value: "> ");
                rover.Convert_StartY_To_Integer();

                // Enter starting direction
                Console.WriteLine(value: "Enter starting direction using one of the following values: N, S, E, W.");
                Console.Write(value: "> ");
                rover.Determine_Starting_Direction();

                // Enter end X coordinate
                Console.WriteLine(value: "Enter final X coordinate. Please only use integers.");
                Console.Write(value: "> ");
                rover.Convert_EndX_To_Integer();

                // Enter end Y coordinate
                Console.WriteLine(value: "Enter final Y coordinate. Please only use integers.");
                Console.Write(value: "> ");
                rover.Convert_EndY_To_Integer();

                // Enter end direction
                Console.WriteLine(value: "Enter end direction using one of the following values: N, S, E, W.");
                Console.Write(value: "> ");
                rover.Determine_End_Direction();

                // Move on X axis (West-East)
                rover.Face_Correct_Direction_WE();
                rover.Move_On_Axis_WE();

                // Move on Y axis (Nort-South)
                rover.Face_Correct_Direction_NS();
                rover.Move_On_Axis_NS();

                // Print directions
                Console.WriteLine(value: $"(Your start coordinates are {rover.Coordinates.StartX}, {rover.Coordinates.StartY}.");
                Console.WriteLine(value: $"(Your starting Direction is {rover.Coordinates.StartD}.");
                if ((rover.Coordinates.DirectionX == "West" || rover.Coordinates.DirectionX == "East") & (rover.Coordinates.DirectionX != rover.Coordinates.StartD))
                {
                    Console.WriteLine(value: $"(Turn {rover.Coordinates.DirectionX}.");
                }
                if (rover.Coordinates.DifferenceX > 0)
                {
                    Console.WriteLine(value: $"(Move {rover.Coordinates.DifferenceX} steps ahead.");
                    }
                if ((rover.Coordinates.DirectionY == "South" || rover.Coordinates.DirectionY == "North") & (rover.Coordinates.DirectionY != rover.Coordinates.DirectionX))
                {
                    Console.WriteLine(value: $"(Turn {rover.Coordinates.DirectionY}.");
                }
                if (rover.Coordinates.DifferenceY > 0)
                {
                    Console.WriteLine(value: $"(Move {rover.Coordinates.DifferenceY} steps ahead.");
                }
                if (rover.Coordinates.DirectionY != rover.Coordinates.EndD)
                {
                    Console.WriteLine(value: $"(Turn {rover.Coordinates.EndD}.");
                }
                Console.WriteLine(value: $"(Your have arrived at coordinate {rover.Coordinates.EndX}, {rover.Coordinates.EndY}.");
                Console.WriteLine(value: $"(You are facing {rover.Coordinates.EndD}.");


            }


        }
    }
}
