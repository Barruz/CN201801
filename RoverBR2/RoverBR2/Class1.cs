using System;

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
    }


}

