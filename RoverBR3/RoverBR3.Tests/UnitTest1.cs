using System;
using Xunit;
using FluentAssertions;

namespace RoverBR3.Tests
{
    public class UnitTest1
    {

// Initial Placement

        // Given coordinates 00N and 00N, instructions will be empty (works for all identical coordinates)
        [Fact]
        public void Coordinates_00N_00N_Return_Empty_Instructions()
        {
            // -- arrange
            var navigator = new Navigator();
            navigator.Start = new Start { X = 0, Y = 0, D = Direction.N };
            navigator.End = new End { X = 0, Y = 0, D = Direction.N };

            // -- act
            navigator.GetInstructions();

            // -- assert
            navigator.Instructions.Should().Be("", "because the start and end coordinates are the same.");
        }

// Movement

        // Turn on spot: Given coordinates 00N and 00E, instructions will be "R"
        [Fact]
        public void Coordinates_00N_00E_Return_R()
        {
            // -- arrange
            var navigator = new Navigator();
            navigator.Start = new Start { X = 0, Y = 0, D = Direction.N };
            navigator.End = new End { X = 0, Y = 0, D = Direction.E };

            // -- act
            navigator.GetInstructions();

            // -- assert
            navigator.Instructions.Should().Be("R", "because to face East, the rover has to turn right");
        }

        // Move without turning, X axis: Given coordinates 00W and -10W, instructions will be "M"
        [Fact]
        public void Coordinates_00W_min40W_Return_MMMM()
        {
            // -- arrange
            var navigator = new Navigator();
            navigator.Start = new Start { X = 0, Y = 0, D = Direction.W };
            navigator.End = new End { X = -1, Y = 0, D = Direction.W };

            // -- act
            navigator.GetInstructions();

            // -- assert
            navigator.Instructions.Should().Be("M", "because the rover doesn't turn and moves 1 time");
        }
        
        // Move more steps without turning, X axis: Given coordinates 00E and 40E, instructions will be "MMMM"
        [Fact]
        public void Coordinates_00E_min40E_Return_MMMM()
        {
            // -- arrange
            var navigator = new Navigator();
            navigator.Start = new Start { X = 0, Y = 0, D = Direction.E };
            navigator.End = new End { X = 4, Y = 0, D = Direction.E };

            // -- act
            navigator.GetInstructions();

            // -- assert
            navigator.Instructions.Should().Be("MMMM", "because the rover moves 4 times");
        }

        // Turn - move East, X axis: Given coordinates 00N and 20E, instructions will be "RMM"
        [Fact]
        public void Coordinates_00N_20E_Return_RMM()
        {
            // -- arrange
            var navigator = new Navigator();
            navigator.Start = new Start { X = 0, Y = 0, D = Direction.N };
            navigator.End = new End { X = 2, Y = 0, D = Direction.E };

            // -- act
            navigator.GetInstructions();

            // -- assert
            navigator.Instructions.Should().Be("RMM", "because the rover turns right and moves 2 times");
        }

        // Turn - move West, X axis: Given coordinates 00N and -50W, instructions will be "LMMMMM"
        [Fact]
        public void Coordinates_00N_min50W_Return_LMMMMM()
        {
            // -- arrange
            var navigator = new Navigator();
            navigator.Start = new Start { X = 0, Y = 0, D = Direction.N };
            navigator.End = new End { X = -5, Y = 0, D = Direction.W };

            // -- act
            navigator.GetInstructions();

            // -- assert
            navigator.Instructions.Should().Be("LMMMMM", "because the rover turns left and moves 5 times");
        }

        // Turn - move East - turn South, X axis: Given coordinates 00N and 30S, instructions will be "RMMMR"
        [Fact]
        public void Coordinates_00N_30S_Return_RMMMR()
        {
            // -- arrange
            var navigator = new Navigator();
            navigator.Start = new Start { X = 0, Y = 0, D = Direction.N };
            navigator.End = new End { X = 3, Y = 0, D = Direction.S };

            // -- act
            navigator.GetInstructions();

            // -- assert
            navigator.Instructions.Should().Be("RMMMR", "because the rover turns right, moves 3 times and turns right");
        }

        // Move North, Y axis: Given coordinates 00N and 01N, instructions will be "M"
        [Fact]
        public void Coordinates_00N_01N_Return_M()
        {
            // -- arrange
            var navigator = new Navigator();
            navigator.Start = new Start { X = 0, Y = 0, D = Direction.N };
            navigator.End = new End { X = 0, Y = 1, D = Direction.N };

            // -- act
            navigator.GetInstructions();

            // -- assert
            navigator.Instructions.Should().Be("M", "because the roves moves once");
        }

        // Turn - Move east - turn - move south - turn, X+Y axis: Given coordinates 2-1N and 0-3W, instructions will be "LMMLMMR"
        [Fact]
        public void Coordinates_2min1N_0min3W_Return_LMMLMMR()
        {
            // -- arrange
            var navigator = new Navigator();
            navigator.Start = new Start { X = 2, Y = -1, D = Direction.N };
            navigator.End = new End { X = 0, Y = -3, D = Direction.W };

            // -- act
            navigator.GetInstructions();

            // -- assert
            navigator.Instructions.Should().Be("LMMLMMR");
        }

// Parsing

        // If entered coordinates (string) are 11N, object X coordinate will be int 1
        [Fact]
        public void Coordinates_11N_Return_X1()
        {
            // -- arrange
            var navigator = new Navigator();
            var coordinates = "1,1,N";
            var coordinates2 = "0,0,N";

            // -- act
            navigator.GetCoordinates(coordinates, coordinates2);

            // -- assert
            navigator.Start.X.ShouldBeEquivalentTo(1);
        }

        // If entered coordinates (string) are 11N, object X,Y coordinates will be int 1, int 1
        [Fact]
        public void Coordinates_11N_Return_X1_Y1()
        {
            // -- arrange
            var navigator = new Navigator();
            var coordinates = "1,1,N";
            var coordinates2 = "0,0,N";


            // -- act
            navigator.GetCoordinates(coordinates, coordinates2);

            // -- assert
            navigator.Start.X.ShouldBeEquivalentTo(1);
            navigator.Start.Y.ShouldBeEquivalentTo(1);
        }

        // If entered coordinates (string) are 11S, object will be int 1, int 1, Direction.S
        [Fact]
        public void If_Coordinates_11S_X_Is_Int1Int1DirectionS()
        {
            // -- arrange
            var navigator = new Navigator();
            var coordinates = "1,1,S";
            var coordinates2 = "0,0,N";

            // -- act
            navigator.GetCoordinates(coordinates, coordinates2);

            // -- assert
            navigator.Start.ShouldBeEquivalentTo(new Start { X = 1, Y = 1, D = Direction.S });
        }

        // If entered coordinates (string) are 11E, starting coords will be int 0, int 0, Direction.E
        [Fact]
        public void If_Coordinates_11E_Start_Is_Int1Int1DirectionE()
        {
            // -- arrange
            var navigator = new Navigator();
            var coordinates = "1,1,E";
            var coordinates2 = "2,2,W";

            // -- act
            navigator.GetCoordinates(coordinates, coordinates2);

            // -- assert
            navigator.Start.ShouldBeEquivalentTo(new Position { X = 1, Y = 1, D = Direction.E });
            navigator.End.ShouldBeEquivalentTo(new Position { X = 2, Y = 2, D = Direction.W });
        }

        // Theories

        [Theory]
        [InlineData("0,0,N", "-2,3,E", "LMMRMMMR")]
        [InlineData("-1,-1,W", "-2,-2,S", "MLM")]
        [InlineData("5,-3,N", "-10,13,S", "LMMMMMMMMMMMMMMMRMMMMMMMMMMMMMMMMLL")]
        public void ProcessThreeInstructions(string coordinates, string coordinates2, string expected_instructions)
        {
            // -- arrange
            var navigator = new Navigator();

            // -- act
            navigator.GetCoordinates(coordinates, coordinates2);

            // -- assert
            navigator.Instructions.ShouldBeEquivalentTo(expected_instructions);
        }


    }
}
