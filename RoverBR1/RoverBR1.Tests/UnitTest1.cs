using System;
using Xunit;
using FluentAssertions;
using GeorgeCloney;

namespace RoverBR1.Tests
{


    [Fact]
    public void StringInCorrectFormat()
    {
        // -- arrange
        var rover = new Rover();

        // -- act
        rover.MoveOnNSAxis("");

        // -- assert
        var EndCoordinates = rover.Coordinates;
        EndCoordinates.ShouldBeEquivalentTo(StartCoordinates, "because we did not move");
    }

}
