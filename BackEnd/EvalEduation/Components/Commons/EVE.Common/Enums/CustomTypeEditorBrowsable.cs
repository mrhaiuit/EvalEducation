using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVE.Commons
{
    /// <summary>
    /// Specifies whether a property should be displayed in a CustomTypeEditor popup screen.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CustomTypeEditorBrowsable: System.Attribute
    {
        private readonly bool _value;
          
        /// <summary>
        /// Specifies the default value for the CustomTypeEditorBrowsable, which CustomTypeEditorBrowsable.Yes. 
        /// This static field is read-only.
        /// </summary>
        public static readonly CustomTypeEditorBrowsable Default = Yes;
        
        /// <summary>
        /// Specifies that a property cannot be displayed to select at design time. 
        /// This static field is read-only.
        /// </summary>
        public static readonly CustomTypeEditorBrowsable No = new CustomTypeEditorBrowsable(false);
        
        /// <summary>
        /// Specifies that a property can be displayed to select at design time. 
        /// This static field is read-only.
        /// </summary>
        public static readonly CustomTypeEditorBrowsable Yes = new CustomTypeEditorBrowsable(true);

        /// <summary>
        /// Initializes a new instance of the CustomTypeEditorBrowsable class.
        /// </summary>
        /// <param name="browsable">
        /// true if a property can be displayed at design time; otherwise, false.
        /// The default is true.
        /// </param>
        public CustomTypeEditorBrowsable(bool browsable)
        {
            _value = browsable;
        }

        /// <summary>
        /// Gets a value indicating whether an object is browsable.
        /// true if the object is browsable; otherwise, false.
        /// </summary>
        public bool Browsable => _value;

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>true if obj is equal to this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            //If parameter is null, return false
            if (obj == null)
            {
                return false;
            }

            //If parameter cannot be cast to CustomTypeEditorBrowsable, return false
            CustomTypeEditorBrowsable p = obj as CustomTypeEditorBrowsable;
            if ((System.Object)p == null)
            {
                return false;
            }

            //Return true if the values match
            return (_value == p._value);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines if this attribute is the default.
        /// </summary>
        /// <returns>true if the attribute is the default value for this attribute class; otherwise, false.</returns>
        public override bool IsDefaultAttribute()
        {
            return (this == Default);
        }
    }

}
