using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace marsrovers.Entities
{
    /* I did not a Interface for Plateau because I assume the Plateau is a entity of low granulaty where is a scenario
     * to the Rovers, avoiding an overloaded engineering.
     */
    public class Plateau
    {
        #region Fields

        private IList<IRover> rovers;

        #endregion

        #region Properties

        /* I made Public Properties to maintain some flexibility in which allows you to change the size of the plateau
         * after instantiated.
         */
        public int LengthX { get; set; }

        public int LengthY { get; set; }

        public IList<IRover> Rovers { get { return rovers ?? (rovers = new List<IRover>()); } }

        #endregion

        #region Constructors

        /* I made this Parameterless Constructor to maintain some flexibility where you can instance the Plateau
         * and assign the Length using the Properties if you prefer.
         */
        public Plateau() {}

        /* I allowed define properties when instantiate to allow more flexibility.
         */
        public Plateau(int lengthX, int lengthY)
        {
            LengthX = lengthX;
            LengthY = lengthY;
        }

        #endregion

        #region Methods

        /* When inserting a Rover in the Plateau you need to insert the Position to avoid the Rover to
         * start in a invalid position in the Plateau.
         * Because of that I did not a overload method where you only insert the rover without the Position.
         */
        public void InsertRover(IRover rover, Position roverPosition)
        {
            if (IsValidPosition(roverPosition))
                rover.Position = roverPosition;
            else
                throw new Exception("Invalid coordinates.");

            Rovers.Add(rover);
        }

        public bool IsValidPosition(Position position)
        {
            return !(position.PositionX > LengthX || position.PositionY > LengthY);
        }

        #endregion
    }
}
