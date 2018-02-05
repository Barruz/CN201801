using System;
using Xunit;
using FluentAssertions;
using GeorgeCloney;

namespace RoverBR1.Tests
{
    public class RoverTests
    {

        [Fact]
        public void IfCoordinatesNotInteger()
        {
            // -- arrange
            var rover = new Rover();
            var initialPosition = rover.Position;

            // -- act
            rover.Move("");

            // -- assert
            var finalPosition = rover.Position;
            finalPosition.ShouldBeEquivalentTo(initialPosition, "because we did not move");
        }

        [Fact]
        public void GivenEmptyInstructionWeStayInPlace()
        {
            // -- arrange
            var rover = new Rover();
            var initialPosition = rover.Position;

            // -- act
            rover.Move("");

            // -- assert
            var finalPosition = rover.Position;
            finalPosition.ShouldBeEquivalentTo(initialPosition, "because we did not move");
        }
    }
}
