namespace EVE.Commons.Attribute
{
    /// <summary>
    ///     This attribute is used to represent a string value
    ///     for a value in an enum.
    /// </summary>
    public class StringValueAttribute : System.Attribute
    {
        #region Constructor

        /// <summary>
        ///     Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            StringValue = value;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion
    }
}
