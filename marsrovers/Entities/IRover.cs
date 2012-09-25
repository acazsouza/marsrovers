using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace marsrovers.Entities
{
    /* I keep a Inteface for Rovers to allow different types of Rovers explore the Plateau.
     */
    public interface IRover
    {
        #region Properties

        Position Position { get; set; }

        #endregion

        #region Methods

        void MoveForward();

        void Spin90DegreesRight();

        void Spin90DegreesLeft();

        string ReportPosition();

        void ExecuteCommandByLetter(char letter);

        #endregion
    }
}
