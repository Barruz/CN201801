using System;

namespace RoverBR1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            int StartX;
            int StartY;
            int EndX;
            int EndY;

            while (true)
            {

                Console.WriteLine(value: "Enter starting X coordinate. Please only use integers.");
                Console.Write(value: "> ");
                var StartX_string = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        StartX = Int32.Parse(StartX_string);
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(value: "Doesn't look like an integer to me! Please try again.");
                        Console.Write(value: "> ");
                        StartX_string = Console.ReadLine();
                    }
                }

                Console.WriteLine(value: "Enter starting Y coordinate. Please only use integers.");
                Console.Write(value: "> ");
                var StartY_string = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        StartY = Int32.Parse(StartY_string);
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(value: "Doesn't look like an integer to me! Please try again.");
                        Console.Write(value: "> ");
                        StartY_string = Console.ReadLine();
                    }
                }
                
                Console.WriteLine(value: "Enter final X coordinate. Please only use integers.");
                Console.Write(value: "> ");
                var EndX_string = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        EndX = Int32.Parse(EndX_string);
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(value: "Doesn't look like an integer to me! Please try again.");
                        Console.Write(value: "> ");
                        EndX_string = Console.ReadLine();
                    }
                }

                Console.WriteLine(value: "Enter final Y coordinate. Please only use integers.");
                Console.Write(value: "> ");
                var EndY_string = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        EndY = Int32.Parse(EndY_string);
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(value: "Doesn't look like an integer to me! Please try again.");
                        Console.Write(value: "> ");
                        EndY_string = Console.ReadLine();
                    }
                }

                Console.WriteLine("Thanks! Your coordinates are {0},{1} and {2},{3}", StartX, StartY, EndX, EndY);

            }


        }
    }
}
