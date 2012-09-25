using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using marsrovers.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace marsrovers.Tests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void MoveForward_with_a_rover_orientation_to_North_should_increase_one_more_in_the_position_Y()
        {
            IRover rover = new Rover(new Position(1, 2, Orientation.North));
            rover.MoveForward();

            Assert.AreEqual(3, rover.Position.PositionY);
        }

        [TestMethod]
        public void MoveForward_with_a_rover_orientation_to_East_should_increase_one_more_in_the_position_X()
        {
            IRover rover = new Rover(new Position(1, 2, Orientation.East));
            rover.MoveForward();

            Assert.AreEqual(2, rover.Position.PositionX);
        }

        [TestMethod]
        public void MoveForward_with_a_rover_orientation_to_South_should_decrease_one_more_in_the_position_Y()
        {
            IRover rover = new Rover(new Position(1, 2, Orientation.South));
            rover.MoveForward();

            Assert.AreEqual(1, rover.Position.PositionY);
        }

        [TestMethod]
        public void MoveForward_with_a_rover_orientation_to_West_should_decrease_one_more_in_the_position_X()
        {
            IRover rover = new Rover(new Position(1, 2, Orientation.West));
            rover.MoveForward();

            Assert.AreEqual(0, rover.Position.PositionX);
        }

        [TestMethod]
        public void Spin90DegreesRight_with_rover_orientation_to_North_should_change_the_orientation_to_East()
        {
            IRover rover = new Rover(new Position(4, 6, Orientation.North));
            rover.Spin90DegreesRight();

            Assert.AreEqual(Orientation.East, rover.Position.Orientation);
        }

        [TestMethod]
        public void Spin90DegreesRight_with_rover_orientation_to_East_should_change_the_orientation_to_South()
        {
            IRover rover = new Rover(new Position(4, 6, Orientation.East));
            rover.Spin90DegreesRight();

            Assert.AreEqual(Orientation.South, rover.Position.Orientation);
        }

        [TestMethod]
        public void Spin90DegreesRight_with_rover_orientation_to_South_should_change_the_orientation_to_West()
        {
            IRover rover = new Rover(new Position(4, 6, Orientation.South));
            rover.Spin90DegreesRight();

            Assert.AreEqual(Orientation.West, rover.Position.Orientation);
        }

        [TestMethod]
        public void Spin90DegreesRight_with_rover_orientation_to_West_should_change_the_orientation_to_North()
        {
            IRover rover = new Rover(new Position(4, 6, Orientation.West));
            rover.Spin90DegreesRight();

            Assert.AreEqual(Orientation.North, rover.Position.Orientation);
        }

        [TestMethod]
        public void Spin90DegreesLeft_with_rover_orientation_to_North_should_change_the_orientation_to_West()
        {
            IRover rover = new Rover(new Position(4, 6, Orientation.North));
            rover.Spin90DegreesLeft();

            Assert.AreEqual(Orientation.West, rover.Position.Orientation);
        }

        [TestMethod]
        public void Spin90DegreesLeft_with_rover_orientation_to_West_should_change_the_orientation_to_South()
        {
            IRover rover = new Rover(new Position(4, 6, Orientation.West));
            rover.Spin90DegreesLeft();

            Assert.AreEqual(Orientation.South, rover.Position.Orientation);
        }

        [TestMethod]
        public void Spin90DegreesLeft_with_rover_orientation_to_South_should_change_the_orientation_to_East()
        {
            IRover rover = new Rover(new Position(4, 6, Orientation.South));
            rover.Spin90DegreesLeft();

            Assert.AreEqual(Orientation.East, rover.Position.Orientation);
        }

        [TestMethod]
        public void Spin90DegreesLeft_with_rover_orientation_to_East_should_change_the_orientation_to_North()
        {
            IRover rover = new Rover(new Position(4, 6, Orientation.East));
            rover.Spin90DegreesLeft();

            Assert.AreEqual(Orientation.North, rover.Position.Orientation);
        }

        [TestMethod]
        public void ReportPosition_should_inform_your_current_position()
        {
            IRover rover = new Rover();
            rover.Position = new Position(2, 2, Orientation.North);

            Assert.AreEqual("2 2 N", rover.ReportPosition());
        }

        [TestMethod]
        public void ExecuteCommandByLetter_with_letter_L_should_call_Spin90DegreesLeft()
        {
            IRover rover = new Rover();
            rover.ExecuteCommandByLetter('L');

            Assert.AreEqual("0 0 W", rover.ReportPosition());
        }

        [TestMethod]
        public void ExecuteCommandByLetter_with_letter_R_should_call_Spin90DegreesRight()
        {
            IRover rover = new Rover();
            rover.ExecuteCommandByLetter('R');

            Assert.AreEqual("0 0 E", rover.ReportPosition());
        }

        [TestMethod]
        public void ExecuteCommandByLetter_with_letter_M_should_call_MoveForward()
        {
            IRover rover = new Rover();
            rover.ExecuteCommandByLetter('M');

            Assert.AreEqual("0 1 N", rover.ReportPosition());
        }

        [TestMethod]
        public void ExecuteCommandByLetter_with_a_invalid_letter_should_do_nothing()
        {
            IRover rover = new Rover();
            rover.ExecuteCommandByLetter('Z');

            Assert.AreEqual("0 0 N", rover.ReportPosition());
        }
    }
}
