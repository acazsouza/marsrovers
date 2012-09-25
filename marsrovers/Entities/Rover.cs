using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using marsrovers.StringValue;

namespace marsrovers.Entities
{
    public class Rover : IRover
    {
        #region Properties

        /* It is the responsibility of the Rover to know its own Position.
         */
        public Position Position { get; set; }

        #endregion

        #region Constructors

        /* Parameterless constructor to allow more flexibility and change the position after instantiated.
         */
        public Rover() {}

        /* Constructor with Position parameter to allow more flexibility.
         */
        public Rover(Position position)
        {
            Position = position;
        }

        #endregion

        #region Methods

        /* It is the responsibility of the Rover to manipulate your own direction and localization.
         */
        public void MoveForward()
        {
            switch (Position.Orientation)
            {
                case Orientation.North:
                    Position = Position.IncreaseOneMoreInPositionY();
                    break;
                case Orientation.East:
                    Position = Position.IncreaseOneMoreInPositionX();
                    break;
                case Orientation.South:
                    Position = Position.DecreaseOneMoreInPositionY();
                    break;
                case Orientation.West:
                    Position = Position.DecreaseOneMoreInPositionX();
                    break;
            }
        }

        public void Spin90DegreesRight()
        {
            Position = Position.Spin90DegreesRight();
        }

        public void Spin90DegreesLeft()
        {
            Position = Position.Spin90DegreesLeft();
        }

        /* It is the responsibility of the Rover to report your own Position.
         */
        public string ReportPosition()
        {
            return string.Format("{0} {1} {2}", Position.PositionX, Position.PositionY, Position.Orientation.GetStringValue());
        }

        /* I can only make public this method and make MoveForward(), Spin90DegreesRight() and Spin90DegreesLeft() private.
         * But I'm not do that to allow more flexibility.
         */
        public void ExecuteCommandByLetter(char letter)
        {
            if ('L' == letter)
            {
                Spin90DegreesLeft();
            } else if ('R' == letter)
            {
                Spin90DegreesRight();
            } else if ('M' == letter)
            {
                MoveForward();
            }
        }

        #endregion
    }
}
