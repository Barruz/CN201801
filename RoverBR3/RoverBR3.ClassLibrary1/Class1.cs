using System;
using System.Linq;

namespace RoverBR3
{
    public enum Direction
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }
    
    public class Start // Stores starting coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction D { get; set; }
    }

    public class End // Stores end coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction D { get; set; }
    }
    
    public class Position // Passes current rover position between different methods
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction D { get; set; }
    }

    public class Navigator
    {
        public Start Start { get; set; } = new Start();
        public End End { get; set; } = new End();
        public Position Position { get; set; } = new Position();
        public Position Init { get; set; } = new Position();
        public string Instructions { get; set; } // Instructions output
        
        public void GetStartCoordinates(string coordinates) // Store starting coordinates in 'start' variables
        {
            Instructions = ""; // Wipe clear in case program is repeated in the same session.
            Parse(coordinates);
            Start = new Start { X = Position.X, Y = Position.Y, D = Position.D };
        }

        public void GetInstructions(string coordinates)
        {
            Parse(coordinates);
            End = new End { X = Position.X, Y = Position.Y, D = Position.D }; // Store end coordinates in 'end' variables
            GetInstructions();
        }

        public void Parse(string coordinates)
        {
            string[] GetPosition = coordinates.Split(','); // Split string, accept only three values
            while (true)
            {
                if (GetPosition.Count() != 3)
                {
                    Console.WriteLine(value: "Incorrect format, please try again.");
                    Console.Write(value: "> ");
                    GetPosition = Console.ReadLine().Split(',');
                }
                else
                    break;
            }

            while(true) // Get X coordinate
            {
                try
                {
                    Position.X = Int32.Parse(GetPosition[0]);
                    break;
                }
                catch
                {
                    Console.WriteLine(value: "Please enter the X coordinate again. Use an integer larger than -2147483648 and smaller than 2147483647.");
                    Console.Write(value: "> ");
                    GetPosition[0] = Console.ReadLine();
                }
            }

            while(true) // Get Y coordinate
            {
                try
                {
                    Position.Y = Int32.Parse(GetPosition[1]);
                    break;
                }
                catch
                {
                    Console.WriteLine(value: "Please enter the Y coordinate again. Use an integer larger than -2147483648 and smaller than 2147483647.");
                    Console.Write(value: "> ");
                    GetPosition[1] = Console.ReadLine();
                }
            }

            do // Get direction
            {
                GetPosition[2] = GetPosition[2].ToUpper();
                switch (GetPosition[2])
                {
                    case "N":
                        Position.D = Direction.N;
                        break;
                    case "S":
                        Position.D = Direction.S;
                        break;
                    case "E":
                        Position.D = Direction.E;
                        break;
                    case "W":
                        Position.D = Direction.W;
                        break;
                    case "":
                    default:
                        Console.WriteLine(value: "Pick one of the following directions: N, S, E, W.");
                        Console.Write("> ");
                        GetPosition[2] = Console.ReadLine();
                        break;
                }
            }
            while ((GetPosition[2] != "N") && (GetPosition[2] != "E") && (GetPosition[2] != "S") && (GetPosition[2] != "W"));
        }

        public void GetInstructions() // Builds string of instructions
        {
            Position.D = Start.D;

            if ((Start.X == End.X) && (Start.Y == End.Y) && (Position.D == End.D)) // If identical end & start coordinates, return empty instructions
            {
                Instructions = "";
            }

            else // if S&E coordinates are not identical
            {
                if (Start.X != End.X) // move on X axis
                {
                    if (Start.X > End.X)
                    {
                        if (Position.D != Direction.W)
                        {
                            Init.D = Direction.W;
                            Turn();
                            Position.D = Direction.W;
                        }
                        int difference = Math.Abs(Start.X - End.X);
                        Move(difference);
                    }

                    else
                    {
                        if (Position.D != Direction.E)
                        {
                            Init.D = Direction.E;
                            Turn();
                            Position.D = Direction.E;
                        }
                        int difference = Math.Abs(End.X - Start.X);
                        Move(difference);
                    }
                }


                if (Start.Y != End.Y) // move on Y axis
                {
                    if (Start.Y > End.Y)
                    {
                        if (Position.D != Direction.S)
                        {
                            Init.D = Direction.S;
                            Turn();
                            Position.D = Direction.S;
                        }
                        int difference = Math.Abs(Start.Y - End.Y);
                        Move(difference);
                    }

                    else
                    {
                        if (Position.D != Direction.N)
                        {
                            Init.D = Direction.N;
                            Turn();
                            Position.D = Direction.N;
                        }
                        int difference = Math.Abs(End.Y - Start.Y);
                        Move(difference);
                    }
                }

                if (Position.D != End.D) // Final turn to face end direction
                {
                    Init.D = End.D;
                    Turn();
                }
            }

        }

        public void Turn() // Turning method
        {
            if ((Position.D == Init.D - 1) || ((Position.D == Direction.W) && (Init.D == Direction.N)))
            {
                Instructions += "R";
            }
            else if ((Init.D == Position.D - 1) || ((Position.D == Direction.N) && (Init.D == Direction.W)))
            {
                Instructions += "L";
            }
            else
            {
                Instructions += "LL";
            }
        }

        public void Move(int difference) // Moving method
        {
            int d = 1;
            do
            {
                Instructions += "M";
                d++;
            }
            while (d <= difference);
        }
        
    }
}