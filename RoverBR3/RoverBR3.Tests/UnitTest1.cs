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

        // Given coordinates 00N and 00N, Instructions will be empty (works for all identical coordinates)
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

        // Turn on spot: Given coordinates 00N and 00E, instructions will be "L"
        [Fact]
        public void Coordinates_00N_00E_Return_L()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = 0, D = Direction.E };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("L", "because to face East, the rover has to turn left");
        }

        // Given coordinates 00W and -40W, instructions will be "MMMM"
        [Fact]
        public void Coordinates_00W_min40W_Return_MMMM()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.W };
            rover.EndCoordinates = new EndCoordinates { X = -4, Y = 0, D = Direction.W };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.Instructions.Should().Be("MMMM", "because the rover moves 4 times");
        }


        // Given coordinates 00E and 40E, instructions will be "MMMM"
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
    }
}
