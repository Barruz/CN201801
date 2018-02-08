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

        // Initial Placement: Given coordinates 00N and 00N, instructions will be empty (works for all identical coordinates)
        [Fact]
        public void Given_Coordinates_00N_00N_Returns_Empty_Instructions()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = 0, D = Direction.N };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.instructions.Should().Be("", "because the start and end coordinates are the same.");
        }

        // Movement: Given coordinates 00N and 00E, instructions will be "turn East"
        [Fact]
        public void Given_Coordinates_00N_00E_Returns_Turn_East()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = 0, D = Direction.E };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.instructions.Should().Be("Turn East.", "because the rover should turn East");
        }

        // Movement: Given coordinates 00N and 00S, instructions will be "turn South"
        [Fact]
        public void Given_Coordinates_00N_00S_Returns_Turn_South()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = 0, D = Direction.S };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.instructions.Should().Be("Turn South.", "because the rover should turn South");
        }
        
        // Movement: Given coordinates 00N and 00W, instructions will be "turn West"
        [Fact]
        public void Given_Coordinates_00N_00W_Returns_Turn_West()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = 0, D = Direction.W };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.instructions.Should().Be("Turn West.", "because the rover should turn West");
        }
        
        // Movement: Given coordinates 00S and 00N, instructions will be "turn North"
        [Fact]
        public void Given_Coordinates_00S_00N_Returns_Turn_North()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.S };
            rover.EndCoordinates = new EndCoordinates { X = 0, Y = 0, D = Direction.N };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.instructions.Should().Be("Turn North.", "because the rover should turn North");
        }

        // Movement: Given coordinates 00E and 10E, instructions will be "Move 1 step forward."
        [Fact]
        public void Given_Coordinates_00E_10E_Returns_Move1Forward()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.E };
            rover.EndCoordinates = new EndCoordinates { X = 1, Y = 0, D = Direction.E };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.instructions.Should().Be("Move 1 steps forward.", "because X1 > X0");
        }

        // Movement: Given coordinates 00W and -10W, instructions will be "Move 1 step forward."
        [Fact]
        public void Given_Coordinates_00W_min10W_Returns_Move1Forward()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.W };
            rover.EndCoordinates = new EndCoordinates { X = -1, Y = 0, D = Direction.W };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.instructions.Should().Be("Move 1 steps forward.", "because X1 > X0");
        }

        // Movement: Given coordinates 00N and -50S, instructions will be "Turn West. Move 5 steps forward. Turn South."
        [Fact]
        public void Given_Coordinates_00N_min5S_Returns_TurnW_Move5_TurnS()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = -5, Y = 0, D = Direction.S };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.instructions.Should().Be("Turn West.Move 5 steps forward.Turn South.", "because X1 > X0");
        }

        // Movement: Given coordinates 00N and 5-7N, instructions will be "Turn East. Move 5 steps forward. Turn South. Move 7 steps forward. Turn North."
        [Fact]
        public void Given_Coordinates_00N_5min7S_Returns_TurnE_Move5_TurnS_Move7_TurnN()
        {
            // -- arrange
            var rover = new Rover();
            rover.StartCoordinates = new StartCoordinates { X = 0, Y = 0, D = Direction.N };
            rover.EndCoordinates = new EndCoordinates { X = -5, Y = -7, D = Direction.N };

            // -- act
            rover.GetInstructions();

            // -- assert
            rover.instructions.Should().Be("Turn West.Move 5 steps forward.Turn South.Move 7 steps forward.Turn North.", "because");
        }

        // Format: If number of input values != 3, returns error message

        // Format: If X, Y != integers, returns error message

        // Format: If D != N/S/W/E/n/s/w/e, returns error message

        // Theory: (0,0,N) (-2,3,E)

        // Theory: (-1,-1,W) (-2,-2,S)

        // Theory: (5,-3,N) (-10,13,S)


    }
}

