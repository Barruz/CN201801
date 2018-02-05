using System;

namespace RoverBR1
{

    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }

    public class Coordinates
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public Direction Direction { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public int DifferenceX { get; set; }
        public int DifferenceY { get; set; }
        public string StartD { get; set; }
        public string EndD { get; set; }
        public string DirectionX { get; set; }
        public string DirectionY { get; set; }
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

        public void Convert_StartY_To_Integer()
        {
            var StartY_string = Console.ReadLine();
            while (true)
            {
                try
                {
                    Coordinates.StartY = Int32.Parse(StartY_string);
                    break;
                }
                catch
                {
                    Console.WriteLine(value: "Doesn't look like an integer to me! Please try again.");
                    Console.Write(value: "> ");
                    StartY_string = Console.ReadLine();
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

        public void Convert_EndY_To_Integer()
        {
            var EndY_string = Console.ReadLine();
            while (true)
            {
                try
                {
                    Coordinates.EndY = Int32.Parse(EndY_string);
                    break;
                }
                catch
                {
                    Console.WriteLine(value: "Doesn't look like an integer to me! Please try again.");
                    Console.Write(value: "> ");
                    EndY_string = Console.ReadLine();
                }
            }
        }

        public void Determine_Starting_Direction()
        {
            while (true)
            {
                Coordinates.StartD = Console.ReadLine();
                if (Coordinates.StartD == "N")
                {
                    Coordinates.StartD = ((Direction)0).ToString();
                    break;
                }
                else if (Coordinates.StartD == "E")
                {
                    Coordinates.StartD = ((Direction)1).ToString();
                    break;
                }
                else if (Coordinates.StartD == "S")
                {
                    Coordinates.StartD = ((Direction)2).ToString();
                    break;
                }
                else if (Coordinates.StartD == "W")
                {
                    Coordinates.StartD = ((Direction)3).ToString();
                    break;
                }
                else
                {
                    Console.WriteLine(value: "Please choose one of the following directions: N, S, E, W.");
                    Console.Write("> ");
                }

            }
        }


        public void Determine_End_Direction()
        {
            while (true)
            {
                Coordinates.EndD = Console.ReadLine();
                if (Coordinates.EndD == "N")
                {
                    Coordinates.EndD = ((Direction)0).ToString();
                    break;
                }
                else if (Coordinates.EndD == "E")
                {
                    Coordinates.EndD = ((Direction)1).ToString();
                    break;
                }
                else if (Coordinates.EndD == "S")
                {
                    Coordinates.EndD = ((Direction)2).ToString();
                    break;
                }
                else if (Coordinates.EndD == "W")
                {
                    Coordinates.EndD = ((Direction)3).ToString();
                    break;
                }
                else
                {
                    Console.WriteLine(value: "Please choose one of the following directions: N, S, E, W.");
                    Console.Write("> ");
                }

            }
        }

        public void Face_Correct_Direction_WE()
        {
            if (Coordinates.StartX > Coordinates.EndX)
            {
                Coordinates.DirectionX = "West";
            }

            else if (Coordinates.StartX < Coordinates.EndX)
            {
                Coordinates.DirectionX = "East";
            }

            else
            {
                Coordinates.DirectionX = Coordinates.StartD;
            }
        }


        public void Move_On_Axis_WE()
        {
            if (Coordinates.StartX > Coordinates.EndX)
                {
                    Coordinates.DifferenceX = Coordinates.StartX - Coordinates.EndX;
            }

            else if (Coordinates.StartX < Coordinates.EndX)
                {
                    Coordinates.DifferenceX = Coordinates.EndX - Coordinates.StartX;
            }

            else
                {
                    Coordinates.DifferenceX = 0;
                }

            Coordinates.DifferenceX = Math.Abs(Coordinates.DifferenceX);
        }

        public void Face_Correct_Direction_NS()
        {
            if (Coordinates.StartY > Coordinates.EndY)
            {
                Coordinates.DirectionY = "South";
            }

            else if (Coordinates.StartY < Coordinates.EndY)
            {
                Coordinates.DirectionY = "North";
            }

            else
            {
                Coordinates.DirectionY = Coordinates.DirectionX;
            }
        }


        public void Move_On_Axis_NS()
        {
            if (Coordinates.StartY > Coordinates.EndY)
            {
                Coordinates.DifferenceY = Coordinates.StartY - Coordinates.EndY;
            }

            else if (Coordinates.StartY < Coordinates.EndY)
            {
                Coordinates.DifferenceY = Coordinates.EndY - Coordinates.StartY;
            }

            else
            {
                Coordinates.DifferenceY = 0;
            }

            Coordinates.DifferenceY = Math.Abs(Coordinates.DifferenceY);
        }


    }



}