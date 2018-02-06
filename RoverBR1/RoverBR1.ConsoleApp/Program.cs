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
                // Enter starting coordinates + starting direction & store in variables
                Console.WriteLine(value: "> Enter starting coordinates and direction. Use the format ‘X,Y,D’, where X and Y are integers and D can have the following values: N, S, E, W.");
                Console.Write(value: "> ");
                rover.Get_Coordinates();
                rover.Store_Start_Variables();

                // Enter end coordinates + end direction & store in variables
                Console.WriteLine(value: "> Enter end coordinates and direction. Use the format ‘X,Y,D’, where X and Y are integers and D can have the following values: N, S, E, W.");
                Console.Write(value: "> ");
                rover.Get_Coordinates();
                rover.Store_End_Variables();
                
                // Find correct direction and move on X axis (West-East) & Y axis (North-South)
                rover.Move_WE();
                rover.Move_NS();

                // Print directions
                rover.Print_Directions();
            }


        }
    }
}
