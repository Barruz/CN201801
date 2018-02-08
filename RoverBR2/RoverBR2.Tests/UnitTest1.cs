using FluentAssertions;
using Xunit;

namespace RoverBR2.Tests
{
    public class RoverTests
    {
        // Initial Placement: Given starting coordinates 1,1,S, rover's start coordinates become 1,1,S 
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
            rover.StartCoordinates.ShouldBeEquivalentTo(new StartCoordinates { X = 1, Y = 1, D = Direction.S}, "because given starting coordinates 11S, starting coordinates should be 11S");
        }

        // Initial Placement: Given end coordinates -1,-1,E, rover's end coordinates become -1,-1,E
        [Fact]
        public void Given_End_Coordinates_min1min1S_Rovers_End_Coordinates_Become_min1min1S()
        {
            // -- arrange
            var rover = new Rover();

            // -- act
            rover.GivenCoordinates = new GivenCoordinates{ X = -1, Y = -1, D = Direction.E };
            rover.GetEndCoordinates();

            // -- assert
            rover.EndCoordinates.ShouldBeEquivalentTo(new EndCoordinates {X = -1, Y = -1, D = Direction.E }, "because given end coordinates -1-1S, end coordinates should be -1-1S");

        }

        // Initial Placement: If start coordinates equal end coordinates, returns empty message

        [Fact]
        public void Given_Identical_Start_And_End_Coordinates_Returns_Empty_Instructions()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 1, Y = 1, D = Direction.E };
            rover.EndCoordinates = new EndCoordinates { X = 1, Y = 1, D = Direction.E };

            // -- act
            rover.StartCoordinatesEqualEndCoordinates();

            // -- assert
            rover.instructions.Should().Be("", "because the start and end coordinates were the same.");
        }



        // Movement: 0,0,N / 0,0,S

        // Movement: 0,0,N / 1,0,N

        // Movement: 0,0,N / 1,0,S

        // Movement: 0,0,N / 1,1,N

        // Movement: 0,0,N / 1,1,E

        // Format: If number of input values != 3, returns error message

        // Format: If X, Y != integers, returns error message

        // Format: If D != N/S/W/E/n/s/w/e, returns error message

        // Theory: (0,0,N) (-2,3,E)

        // Theory: (-1,-1,W) (-2,-2,S)

        // Theory: (5,-3,N) (-10,13,S)


    }
}

