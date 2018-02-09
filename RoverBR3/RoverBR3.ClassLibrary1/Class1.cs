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
        public string TestInput { get; set; }

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
            TestInput = TestInput.ToUpper();
            string[] GetCoordinates = TestInput.Split(',');
            GivenCoordinates.X = Int32.Parse(GetCoordinates[0]);
            GivenCoordinates.Y = Int32.Parse(GetCoordinates[1]);

            switch (GetCoordinates[2])
            {
                case "N":
                    GivenCoordinates.D = Direction.N;
                    break;
                case "S":
                    GivenCoordinates.D = Direction.S;
                    break;
                case "E":
                    GivenCoordinates.D = Direction.E;
                    break;
                case "W":
                    GivenCoordinates.D = Direction.W;
                    break;
                default:
                    Console.WriteLine(value: "Pick one of the following directions: N, S, E, W.");
                    Console.Write("> ");
                    GetCoordinates[2] = Console.ReadLine();
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

                        if (StartCoordinates.D != Direction.W)
                        {
                            switch (StartCoordinates.D)
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
                            StartCoordinates.D = Direction.W;
                        }

                        int d = 1;
                        do
                        {
                            Instructions += "M";
                            d++;
                        }
                        while (d <= DifferenceX);
                        
                    }

                    if (StartCoordinates.X < EndCoordinates.X)
                    {
                        int DifferenceX = EndCoordinates.X - StartCoordinates.X;
                        DifferenceX = Math.Abs(DifferenceX);

                        if (StartCoordinates.D != Direction.E)
                        {
                            switch (StartCoordinates.D)
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
                            StartCoordinates.D = Direction.E;
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


                if (StartCoordinates.Y != EndCoordinates.Y)
                {
                    if (StartCoordinates.Y > EndCoordinates.Y)
                    {
                        int DifferenceY = StartCoordinates.Y - EndCoordinates.Y;
                        DifferenceY = Math.Abs(DifferenceY);

                        if (StartCoordinates.D != Direction.S)
                        {
                            switch (StartCoordinates.D)
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
                            StartCoordinates.D = Direction.S;
                        }

                        int d = 1;
                        do
                        {
                            Instructions += "M";
                            d++;
                        }
                        while (d <= DifferenceY);

                    }

                    if (StartCoordinates.Y < EndCoordinates.Y)
                    {
                        int DifferenceY = EndCoordinates.Y - StartCoordinates.Y;
                        DifferenceY = Math.Abs(DifferenceY);

                        if (StartCoordinates.D != Direction.N)
                        {
                            switch (StartCoordinates.D)
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
                            StartCoordinates.D = Direction.N;
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



                if (StartCoordinates.D != EndCoordinates.D)
                {
                    if (StartCoordinates.D == Direction.N)
                    {
                        if (EndCoordinates.D == Direction.E)
                        {
                            Instructions += "R";
                        }
                        else if (EndCoordinates.D == Direction.S)
                        {
                            Instructions += "LL";
                        }
                        else if (EndCoordinates.D == Direction.W)
                        {
                            Instructions += "L";
                        }
                    }

                    if (StartCoordinates.D == Direction.E)
                    {
                        if (EndCoordinates.D == Direction.N)
                        {
                            Instructions += "L";
                        }
                        else if (EndCoordinates.D == Direction.S)
                        {
                            Instructions += "R";
                        }
                        else if (EndCoordinates.D == Direction.W)
                        {
                            Instructions += "LL";
                        }
                        
                    }

                    if (StartCoordinates.D == Direction.S)
                    {
                        if (EndCoordinates.D == Direction.E)
                        {
                            Instructions += "L";
                        }
                        else if (EndCoordinates.D == Direction.N)
                        {
                            Instructions += "LL";
                        }
                        else if (EndCoordinates.D == Direction.W)
                        {
                            Instructions += "R";
                        }
                        
                    }

                    if (StartCoordinates.D == Direction.W)
                    {
                        if (EndCoordinates.D == Direction.E)
                        {
                            Instructions += "LL";
                        }
                        else if (EndCoordinates.D == Direction.S)
                        {
                            Instructions += "L";
                        }
                        else if (EndCoordinates.D == Direction.N)
                        {
                            Instructions += "R";
                        }
                        
                    }
                }




                
            }


        }
    }


}