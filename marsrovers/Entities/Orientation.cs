using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using marsrovers.StringValue;

namespace marsrovers.Entities
{
    /* I used an ENUM for Orientation to ensure the type-safe in compilation time and avoid errors. I think it is also more readable.
     */
    public enum Orientation : byte
    {
        /* This attribute is used to facilitate the orientation report.
         */
        [StringValue("N")]
        North,
        [StringValue("E")]
        East,
        [StringValue("S")]
        South,
        [StringValue("W")]
        West
    }
}
