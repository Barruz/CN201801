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
        //Starting coordinates input by user
        public int StartX { get; set; }
        public int StartY { get; set; }
        public string StartD { get; set; }

        //End coordinates input by user
        public int EndX { get; set; }
        public int EndY { get; set; }
        public string EndD { get; set; }

        //Variables allowing for the use of one method for both starting and end coordinates
        public int EnteredX { get; set; }
        public int EnteredY { get; set; }
        public string EnteredD { get; set; }

        //Number of steps between starting and end coordinates
        public int DifferenceX { get; set; }
        public int DifferenceY { get; set; }

        //Start, end and turning directions
        public string DirectionX { get; set; }
        public string DirectionY { get; set; }
        public Direction Direction { get; set; }
    } 

    public class Rover
    {
        public Coordinates Coordinates { get; set; } = new Coordinates();

        // Get start and end XYD coordinates input by user. Runs twice, once for starting coordinates, once for end coordinates
        public void Get_Coordinates()
        {
            string[] Get_Coordinates = Console.ReadLine().Split(',');
            
            // Get X Coordinate
            string Entered_Coordinates = Get_Coordinates[0];
                while (true)
                {
                    try
                    {
                        Coordinates.EnteredX = Int32.Parse(Entered_Coordinates);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine(value: "X coordinate was not an integer. Please enter the X coordinate again.");
                        Console.Write(value: "> ");
                        Entered_Coordinates = Console.ReadLine();
                    }
                }

            // Get Y Coordinate
            Entered_Coordinates = Get_Coordinates[1];
                while (true)
                {
                    try
                    {
                        Coordinates.EnteredY = Int32.Parse(Entered_Coordinates);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine(value: "Y coordinate was not an integer. Please enter the Y coordinate again.");
                        Console.Write(value: "> ");
                        Entered_Coordinates = Console.ReadLine();
                    }
                }

            // Get direction
            Coordinates.EnteredD = Get_Coordinates[2];
                while (true)
                {
                    if (Coordinates.EnteredD == "N" || Coordinates.EnteredD == "n")
                    {
                        Coordinates.EnteredD = ((Direction)0).ToString();
                        break;
                    }
                    else if (Coordinates.EnteredD == "E" || Coordinates.EnteredD == "e")
                    {
                        Coordinates.EnteredD = ((Direction)1).ToString();
                        break;
                    }
                    else if (Coordinates.EnteredD == "S" || Coordinates.EnteredD == "s")
                    {
                        Coordinates.EnteredD = ((Direction)2).ToString();
                        break;
                    }
                    else if (Coordinates.EnteredD == "W" || Coordinates.EnteredD == "w")
                    {
                        Coordinates.EnteredD = ((Direction)3).ToString();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(value: "Please choose one of the following directions: N, S, E, W.");
                        Console.Write("> ");
                        Coordinates.EnteredD = Console.ReadLine();
                    }
                    
                }
        }
        
        // Store starting coordinates in 'Start' variables
        public void Store_Start_Variables()
        {
            Coordinates.StartX = Coordinates.EnteredX;
            Coordinates.StartY = Coordinates.EnteredY;
            Coordinates.StartD = Coordinates.EnteredD;
        }

        // Store end coordinates in 'End' variables
        public void Store_End_Variables()
        {
            Coordinates.EndX = Coordinates.EnteredX;
            Coordinates.EndY = Coordinates.EnteredY;
            Coordinates.EndD = Coordinates.EnteredD;
        }

        // Face the correct direction on the X (W-E) axis & move
        public void Move_WE()
        {
            //face correct direction
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
            
            //move
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

        // Face the correct direction on the Y (N-S) axis & move
        public void Move_NS()
        {
            // Face correct direction
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

            // Move
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

        //Print directions
        public void Print_Directions()
        {
            Console.WriteLine(value: $"(Your starting coordinates are {Coordinates.StartX}, {Coordinates.StartY}. You are facing {Coordinates.StartD}.");
            if ((Coordinates.DirectionX == "West" || Coordinates.DirectionX == "East") && (Coordinates.DirectionX != Coordinates.StartD))
            {
                Console.WriteLine(value: $"(Turn {Coordinates.DirectionX}.");
            }
            if (Coordinates.DifferenceX > 0)
            {
                Console.WriteLine(value: $"(Move {Coordinates.DifferenceX} steps forward.");
            }
            if ((Coordinates.DirectionY == "South" || Coordinates.DirectionY == "North") & (Coordinates.DirectionY != Coordinates.DirectionX))
            {
                Console.WriteLine(value: $"(Turn {Coordinates.DirectionY}.");
            }
            if (Coordinates.DifferenceY > 0)
            {
                Console.WriteLine(value: $"(Move {Coordinates.DifferenceY} steps forward.");
            }
            if (Coordinates.DirectionY != Coordinates.EndD)
            {
                Console.WriteLine(value: $"(Turn {Coordinates.EndD}.");
            }
            Console.WriteLine(value: $"(Your have arrived at coordinates {Coordinates.EndX}, {Coordinates.EndY}. You are facing {Coordinates.EndD}.");
            Console.WriteLine(value: "> ");
        }
    }
}