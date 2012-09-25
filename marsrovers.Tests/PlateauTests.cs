using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using marsrovers.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace marsrovers.Tests
{
    [TestClass]
    public class PlateauTests
    {
        [TestMethod]
        public void Plateau_constructor_with_5_and_5_should_get_a_instance_of_plateau_with_5_of_lenght_X_and_5_of_length_Y()
        {
            var plateau = new Plateau(5, 5);
            Assert.AreEqual(5, plateau.LengthX);
            Assert.AreEqual(5, plateau.LengthY);
        }

        [TestMethod]
        public void InsertRover_with_a_instance_of_a_rover_and_a_valid_position_should_insert_the_rover_in_the_reported_position()
        {
            var plateau = new Plateau(5, 5);

            plateau.InsertRover(new Rover(), new Position(1, 2, Orientation.North));

            Assert.AreEqual(1, plateau.Rovers[0].Position.PositionX);
            Assert.AreEqual(2, plateau.Rovers[0].Position.PositionY);
            Assert.AreEqual(Orientation.North, plateau.Rovers[0].Position.Orientation);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InsertRover_with_a_invalid_position_should_throw_a_exception_with_a_error_message()
        {
            var plateau = new Plateau(5, 5);

            try
            {
                plateau.InsertRover(new Rover(), new Position(5, 6, Orientation.North));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid coordinates.", ex.Message);
                throw;
            }
        }
    }
}
