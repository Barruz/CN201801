using System;
using System.Linq;

namespace RoverBR2
{
    public enum Direction
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }

    public class GivenCoordinates
    {
        // Variables entered by user, before being assigned to start/end coordinates
        public int X { get; set; }
        public int Y { get; set; }
        public Direction D { get; set; }
    }

    public class StartCoordinates
    {
        // Start coordinates
        public int X { get; set; }
        public int Y { get; set; }
        public Direction D { get; set; }
    }

    public class EndCoordinates
    {
        // End coordinates
        public int X { get; set; }
        public int Y { get; set; }
        public Direction D { get; set; }
    }

    public class Rover
    {
        public GivenCoordinates GivenCoordinates { get; set; } = new GivenCoordinates();
        public StartCoordinates StartCoordinates { get; set; } = new StartCoordinates();
        public EndCoordinates EndCoordinates { get; set; } = new EndCoordinates();
        public string Instructions { get; set; }
        public string FormattingInstructions { get; set; }
        public string Input { get; set; }

        public void GetStartingCoordinates()
        {
            StartCoordinates.X = GivenCoordinates.X;
            StartCoordinates.Y = GivenCoordinates.Y;
            StartCoordinates.D = GivenCoordinates.D;
        }

        public void GetEndCoordinates()
        {
            EndCoordinates.X = GivenCoordinates.X;
            EndCoordinates.Y = GivenCoordinates.Y;
            EndCoordinates.D = GivenCoordinates.D;
        }

        public void GetCoordinates()
        {
            string[] Input2 = Input.Split(',');
            while (true)
            {
                if (Input2.Count() != 3)
                {
                    FormattingInstructions = "Please try again.";
                    Console.WriteLine(FormattingInstructions);
                    Console.ReadLine();
                }
                else
                    break;
            }
        }

        public void GetInstructions()
        {
            
            if ((StartCoordinates.X == EndCoordinates.X) && (StartCoordinates.Y == EndCoordinates.Y) && (StartCoordinates.D == EndCoordinates.D))
            {
                Instructions = "";
            }

            else
            {
                if (StartCoordinates.X != EndCoordinates.X)
                {
                    if (StartCoordinates.X > EndCoordinates.X)
                    {
                        int DifferenceX = StartCoordinates.X - EndCoordinates.X;
                        DifferenceX = Math.Abs(DifferenceX);

                        if (StartCoordinates.D == Direction.W)
                        {
                            Instructions = $"Move {DifferenceX} steps forward.";
                        }

                        else
                        {
                            Instructions = "Turn West.";
                            Instructions += $"Move {DifferenceX} steps forward.";
                            StartCoordinates.D = Direction.W;
                        }
                    }

                    else
                    {
                        int DifferenceX = EndCoordinates.X - StartCoordinates.X;
                        DifferenceX = Math.Abs(DifferenceX);

                        if (StartCoordinates.D == Direction.E)
                        {
                            Instructions = $"Move {DifferenceX} steps forward.";
                        }
                        else
                        {
                            Instructions = "Turn East.";
                            Instructions += $"Move {DifferenceX} steps forward.";
                            StartCoordinates.D = Direction.E;
                        }
                    }
                }

                if (StartCoordinates.Y != EndCoordinates.Y)
                {
                    if (StartCoordinates.Y > EndCoordinates.Y)
                    {
                        int DifferenceY = StartCoordinates.Y - EndCoordinates.Y;
                        DifferenceY = Math.Abs(DifferenceY);

                        if (StartCoordinates.D == Direction.S)
                        {
                            Instructions += $"Move {DifferenceY} steps forward.";
                        }

                        else
                        {
                            Instructions += "Turn South.";
                            Instructions += $"Move {DifferenceY} steps forward.";
                            StartCoordinates.D = Direction.S;
                        }
                    }

                    else
                    {
                        int DifferenceY = EndCoordinates.Y - StartCoordinates.Y;
                        DifferenceY = Math.Abs(DifferenceY);

                        if (StartCoordinates.D == Direction.N)
                        {
                            Instructions += $"Move {DifferenceY} steps forward.";
                        }
                        else
                        {
                            Instructions += "Turn North.";
                            Instructions += $"Move {DifferenceY} steps forward.";
                            StartCoordinates.D = Direction.N;
                        }
                    }
                }

                if (StartCoordinates.D != EndCoordinates.D)
                {
                    switch (EndCoordinates.D)
                    {
                        case Direction.N:
                            Instructions += "Turn North.";
                            break;
                        case Direction.E:
                            Instructions += "Turn East.";
                            break;
                        case Direction.S:
                            Instructions += "Turn South.";
                            break;
                        case Direction.W:
                            Instructions += "Turn West.";
                            break;
                    }
                }
            }

            
        }
    }


}

