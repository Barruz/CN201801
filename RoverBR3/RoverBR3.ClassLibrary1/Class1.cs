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

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction D { get; set; }
    }

    public class Start
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction D { get; set; }
    }

    public class End
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction D { get; set; }
    }

    public class Navigator
    {
        public Position Position { get; set; } = new Position();
        public Start Start { get; set; } = new Start();
        public End End { get; set; } = new End();
        public string Instructions { get; set; }
        
        public void GetCoordinates(string coordinates, string coordinates2)
        {
            Parse(coordinates);
                Start.X = Position.X;
                Start.Y = Position.Y;
                Start.D = Position.D;
            coordinates = coordinates2;
            Parse(coordinates);
                End.X = Position.X;
                End.Y = Position.Y;
                End.D = Position.D;
            GetInstructions();
        }

        public void Parse(string coordinates)
        {
            coordinates = coordinates.ToUpper();
            string[] GetPosition = coordinates.Split(',');
            Position.X = Int32.Parse(GetPosition[0]);
            Position.Y = Int32.Parse(GetPosition[1]);

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
                default:
                    Console.WriteLine(value: "Pick one of the following directions: N, S, E, W.");
                    Console.Write("> ");
                    GetPosition[2] = Console.ReadLine();
                    break;
            }
        }

        public void GetInstructions()
        {
            if ((Start.X == End.X) && (Start.Y == End.Y) && (Start.D == End.D))
            {
                Instructions = "";
            }

            else
            {
                if (Start.X != End.X)
                {
                    if (Start.X > End.X)
                    {
                        int DifferenceX = Start.X - End.X;
                        DifferenceX = Math.Abs(DifferenceX);

                        if (Start.D != Direction.W)
                        {
                            switch (Start.D)
                            {
                                case Direction.N:
                                    Instructions += "L";
                                    break;
                                case Direction.S:
                                    Instructions += "R";
                                    break;
                                case Direction.E:
                                    Instructions += "LL";
                                    break;
                            }
                            Start.D = Direction.W;
                        }

                        int d = 1;
                        do
                        {
                            Instructions += "M";
                            d++;
                        }
                        while (d <= DifferenceX);

                    }

                    else
                    {
                        int DifferenceX = End.X - Start.X;
                        DifferenceX = Math.Abs(DifferenceX);

                        if (Start.D != Direction.E)
                        {
                            switch (Start.D)
                            {
                                case Direction.N:
                                    Instructions += "R";
                                    break;
                                case Direction.S:
                                    Instructions += "L";
                                    break;
                                case Direction.W:
                                    Instructions += "LL";
                                    break;
                            }
                            Start.D = Direction.E;
                        }

                        int d = 1;
                        do
                        {
                            Instructions += "M";
                            d++;
                        }
                        while (d <= DifferenceX);
                    }
                }


                if (Start.Y != End.Y)
                {
                    if (Start.Y > End.Y)
                    {
                        int DifferenceY = Start.Y - End.Y;
                        DifferenceY = Math.Abs(DifferenceY);

                        if (Start.D != Direction.S)
                        {
                            switch (Start.D)
                            {
                                case Direction.N:
                                    Instructions += "LL";
                                    break;
                                case Direction.W:
                                    Instructions += "L";
                                    break;
                                case Direction.E:
                                    Instructions += "L";
                                    break;
                            }
                            Start.D = Direction.S;
                        }

                        int d = 1;
                        do
                        {
                            Instructions += "M";
                            d++;
                        }
                        while (d <= DifferenceY);

                    }

                    else
                    {
                        int DifferenceY = End.Y - Start.Y;
                        DifferenceY = Math.Abs(DifferenceY);

                        if (Start.D != Direction.N)
                        {
                            switch (Start.D)
                            {
                                case Direction.E:
                                    Instructions += "L";
                                    break;
                                case Direction.S:
                                    Instructions += "LL";
                                    break;
                                case Direction.W:
                                    Instructions += "R";
                                    break;
                            }
                            Start.D = Direction.N;
                        }

                        int d = 1;
                        do
                        {
                            Instructions += "M";
                            d++;
                        }
                        while (d <= DifferenceY);
                    }
                }
                
                if (Start.D != End.D)
                {
                    if (Start.D == Direction.N)
                    {
                        if (End.D == Direction.E)
                        {
                            Instructions += "R";
                        }
                        else if (End.D == Direction.S)
                        {
                            Instructions += "LL";
                        }
                        else if (End.D == Direction.W)
                        {
                            Instructions += "L";
                        }
                    }

                    if (Start.D == Direction.E)
                    {
                        if (End.D == Direction.N)
                        {
                            Instructions += "L";
                        }
                        else if (End.D == Direction.S)
                        {
                            Instructions += "R";
                        }
                        else if (End.D == Direction.W)
                        {
                            Instructions += "LL";
                        }

                    }

                    if (Start.D == Direction.S)
                    {
                        if (End.D == Direction.E)
                        {
                            Instructions += "L";
                        }
                        else if (End.D == Direction.N)
                        {
                            Instructions += "LL";
                        }
                        else if (End.D == Direction.W)
                        {
                            Instructions += "R";
                        }

                    }

                    if (Start.D == Direction.W)
                    {
                        if (End.D == Direction.E)
                        {
                            Instructions += "LL";
                        }
                        else if (End.D == Direction.S)
                        {
                            Instructions += "L";
                        }
                        else if (End.D == Direction.N)
                        {
                            Instructions += "R";
                        }

                    }
                }
            }

        }
    }
    
}