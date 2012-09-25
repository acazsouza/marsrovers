using System;

namespace marsrovers.StringValue
{
    public class StringValueAttribute : Attribute
    {
        #region Properties

        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        public StringValueAttribute(string value)
        {
            StringValue = value;
        }

        #endregion
    }
}
