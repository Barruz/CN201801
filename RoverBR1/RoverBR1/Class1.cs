using System;

namespace RoverBR1
{
    public class StartingPosition
    {
        public int startX { get; set; }
        public int startY { get; set; }
    }


    public enum Direction
    {
        North = 0,
        East,
        South,
        West
    }

    public class Position
    {
        public Direction Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Rover
    {
        public Position Position { get; set; } = new Position();
        public void Move(string instruction)
        {
            if (instruction == "M")
            {
                if (Position.Direction == Direction.North)
                {
                    Position.Y += 1;
                }
                if (Position.Direction == Direction.East)
                {
                    Position.X += 1;
                }
            }

            if (instruction == "R")
            {
                var d = Position.Direction + 1;
                if (d == (Direction)4)
                {
                    d = Direction.North;
                }
                Position.Direction = d;
            }

            if (instruction == "L")
            {
                var d = Position.Direction - 1;
                if (d == (Direction)(-1))
                {
                    d = Direction.West;
                }
                Position.Direction = d;
            }

        }
    }
}