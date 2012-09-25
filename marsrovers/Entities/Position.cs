using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace marsrovers.Entities
{
    /* I do a struct for Position because the Position represents a single value in the current context,
     * therefore, we gain performance with this Struct which is less than 16 bytes.
     */
    public struct Position
    {
        #region Properties

        /* I kept the Properties Set private to make the struct immutable and keep "value semantics".
         */
        public int PositionX { get; private set; }

        public int PositionY { get; private set; }

        public Orientation Orientation { get; private set; }

        #endregion

        #region Constructors

        public Position(int positionX, int positionY, Orientation orientation) : this()
        {
            PositionX = positionX;
            PositionY = positionY;
            Orientation = orientation;
        }

        #endregion

        #region Methods

        /* I think is responsibility of Position to manipulate itself and always generate a new value each manipulation
         * because it is immutable like "String" or "DateTime".
         */
        public Position IncreaseOneMoreInPositionX()
        {
            return new Position(++PositionX, PositionY, Orientation);
        }

        public Position IncreaseOneMoreInPositionY()
        {
            return new Position(PositionX, ++PositionY, Orientation);
        }

        public Position DecreaseOneMoreInPositionX()
        {
            return new Position(--PositionX, PositionY, Orientation);
        }

        public Position DecreaseOneMoreInPositionY()
        {
            return new Position(PositionX, --PositionY, Orientation);
        }

        public Position Spin90DegreesRight()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    return new Position(PositionX, PositionY, Orientation.East);
                case Orientation.East:
                    return new Position(PositionX, PositionY, Orientation.South);
                case Orientation.South:
                    return new Position(PositionX, PositionY, Orientation.West);
                case Orientation.West:
                    return new Position(PositionX, PositionY, Orientation.North);
                default:
                    return new Position();
            }
        }

        public Position Spin90DegreesLeft()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    return new Position(PositionX, PositionY, Orientation.West);
                case Orientation.West:
                    return new Position(PositionX, PositionY, Orientation.South);
                case Orientation.South:
                    return new Position(PositionX, PositionY, Orientation.East);
                case Orientation.East:
                    return new Position(PositionX, PositionY, Orientation.North);
                default:
                    return new Position();
            }
        }

        #endregion
    }
}
