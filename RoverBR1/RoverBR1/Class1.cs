using System;

namespace RoverBR1
{

  public class Coordinates
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
    } 

    public class Rover
    {
        public Coordinates Coordinates { get; set; } = new Coordinates();
        public void Convert_StartX_To_Integer()
        {
            var StartX_string = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        Coordinates.StartX = Int32.Parse(StartX_string);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine(value: "Doesn't look like an integer to me! Please try again.");
                        Console.Write(value: "> ");
                        StartX_string = Console.ReadLine();
                    }
                }
        }

        public void Convert_EndX_To_Integer()
        {
            var EndX_string = Console.ReadLine();
            while (true)
            {
                try
                {
                    Coordinates.EndX = Int32.Parse(EndX_string);
                    break;
                }
                catch
                {
                    Console.WriteLine(value: "Doesn't look like an integer to me! Please try again.");
                    Console.Write(value: "> ");
                    EndX_string = Console.ReadLine();
                }
            }
        }


    }



}