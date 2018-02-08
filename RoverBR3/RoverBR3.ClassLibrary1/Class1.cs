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
                            int d = 1;
                            do
                            {
                                Instructions += "M";
                                d++;
                            }
                            while (d <= DifferenceX);
                        }

                    }

                    if (StartCoordinates.X < EndCoordinates.X)
                    {
                        int DifferenceX = EndCoordinates.X - StartCoordinates.X;
                        DifferenceX = Math.Abs(DifferenceX);

                        if (StartCoordinates.D == Direction.E)
                        {
                            int d = 1;
                            do
                            {
                                Instructions += "M";
                                d++;
                            }
                            while (d <= DifferenceX);
                        }

                    }

                }

                if (StartCoordinates.D != EndCoordinates.D)
                {
                    if (StartCoordinates.D == Direction.N)
                    {
                        if (EndCoordinates.D == Direction.E)
                        {
                            Instructions += "L";
                        }
                        else if (EndCoordinates.D == Direction.S)
                        {
                            Instructions += "LL";
                        }
                        else if (EndCoordinates.D == Direction.W)
                        {
                            Instructions += "R";
                        }

                        else
                        {
                            Instructions += "";
                        }
                    }
                }




                
            }


        }
    }


}