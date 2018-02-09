using System;
using Xunit;
using FluentAssertions;

namespace RoverBR3.Tests
{
    public class UnitTest1
    {

// Initial Placement

        // Given starting coordinates 1,1,S, rover's start coordinates become 1,1,S
        // (not using 00N, because it's the default value for all Coordinates variables)
        [Fact]
        public void Given_Starting_Coordinates_11S_Rovers_Start_Coordinates_Become_11S()
        {
            // -- arrange
            var rover = new Rover();

            // -- act
            rover.GivenCoordinates = new GivenCoordinates { X = 1, Y = 1, D = Direction.S };
            rover.GetStartingCoordinates();

            // -- assert
            rover.StartCoordinates.ShouldBeEquivalentTo(new StartCoordinates { X = 1, Y = 1, D = Direction.S }, "because given starting coordinates 11S, starting coordinates should be 11S");
        }

        // Given coordinates 00N and 00N, instructions will be empty (works for all identical coordinates)
        [Fact]
        public void Coordinates_00N_00N_Return_Empty_Instructions()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = 0, D = Direction.N };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("", "because the start and end coordinates are the same.");
        }

// Movement

        // Turn on spot: Given coordinates 00N and 00E, instructions will be "R"
        [Fact]
        public void Coordinates_00N_00E_Return_R()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = 0, D = Direction.E };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("R", "because to face East, the rover has to turn right");
        }

        // Move without turning, X axis: Given coordinates 00W and -10W, instructions will be "M"
        [Fact]
        public void Coordinates_00W_min40W_Return_MMMM()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.W };
            rover.EndCoordinates = new EndCoordinates { X = -1, Y = 0, D = Direction.W };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("M", "because the rover doesn't turn and moves 1 time");
        }
        
        // Move more steps without turning, X axis: Given coordinates 00E and 40E, instructions will be "MMMM"
        [Fact]
        public void Coordinates_00E_min40E_Return_MMMM()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.E };
            rover.EndCoordinates = new EndCoordinates { X = 4, Y = 0, D = Direction.E };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("MMMM", "because the rover moves 4 times");
        }

        // Turn - move East, X axis: Given coordinates 00N and 20E, instructions will be "RMM"
        [Fact]
        public void Coordinates_00N_20E_Return_RMM()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 2, Y = 0, D = Direction.E };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("RMM", "because the rover turns right and moves 2 times");
        }

        // Turn - move West, X axis: Given coordinates 00N and -50W, instructions will be "LMMMMM"
        [Fact]
        public void Coordinates_00N_min50W_Return_LMMMMM()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = -5, Y = 0, D = Direction.W };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("LMMMMM", "because the rover turns left and moves 5 times");
        }

        // Turn - move East - turn South, X axis: Given coordinates 00N and 30S, instructions will be "RMMMR"
        [Fact]
        public void Coordinates_00N_30S_Return_RMMMR()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 3, Y = 0, D = Direction.S };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("RMMMR", "because the rover turns right, moves 3 times and turns right");
        }

        // Move North, Y axis: Given coordinates 00N and 01N, instructions will be "M"
        [Fact]
        public void Coordinates_00N_01N_Return_M()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = 1, D = Direction.N };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("M", "because the rover move once");
        }

        // Turn - Move east - turn - move south - turn, X+Y axis: Given coordinates 2-1N and 0-3W, instructions will be "LMMLMMR"
        [Fact]
        public void Coordinates_2min1N_0min3W_Return_LMMLMMR()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 2, Y = -1, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = -3, D = Direction.W };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("LMMLMMR", "because");
        }

// Parsing

        // If entered coordinates (string) are 11N, object X coordinate will be int 1
        [Fact]
        public void Coordinates_11N_Return_X1()
        {
            // -- arrange
            var rover = new Rover();
            rover.TestInput = "1,1,N";

            // -- act
            rover.GetCoordinates();

            // -- assert
            rover.GivenCoordinates.X.ShouldBeEquivalentTo(1);
        }

        // If entered coordinates (string) are 11N, object X,Y coordinates will be int 1, int 1
        [Fact]
        public void Coordinates_11N_Return_X1_Y1()
        {
            // -- arrange
            var rover = new Rover();
            rover.TestInput = "1,1,N";

            // -- act
            rover.GetCoordinates();

            // -- assert
            rover.GivenCoordinates.X.ShouldBeEquivalentTo(1);
            rover.GivenCoordinates.Y.ShouldBeEquivalentTo(1);
        }

        // If entered coordinates (string) are 11S, object will be int 0, int 0, Direction.S
        [Fact]
        public void If_Coordinates_11S_X_Is_Int1Int1DirectionS()
        {
            // -- arrange
            var rover = new Rover();
            rover.TestInput = "1,1,S";

            // -- act
            rover.GetCoordinates();

            // -- assert
            rover.GivenCoordinates.ShouldBeEquivalentTo(new GivenCoordinates { X = 1, Y = 1, D = Direction.S });
        }

    }
}
