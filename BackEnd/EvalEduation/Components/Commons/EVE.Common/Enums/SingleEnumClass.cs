// <copyright file="CimSource.cs" company="TCIS">
// Copyright (c) .  All rights reserved.  Reproduction or transmission in 
// whole or in part, in any form or by any means, electronic, mechanical or 
// otherwise, is prohibited without the prior written consent of the copyright 
// owner.
// </copyright>
//
// <summary>
// </summary>
// <remarks>
// </remarks>
// <history>
// Date         Release         Task            Who         Summary
// ===================================================================================
// 24/09/2012   1.0.0.0                         LKTL        Created
// </history>
using System;

namespace EVE.Commons
{
    
    public abstract class StringEnumClass: System.Object
    {
        private readonly String _value;
         /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        public StringEnumClass(String code)
        {
            this._value = code;
        }

        /// <summary>
        /// Override ToString() method. Return 'value'  of instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _value;
        }

        /// <summary>
        /// Overloads operator ==
        /// </summary>
        /// <param name="firstOperator"></param>
        /// <param name="secondOperator"></param>
        /// <returns></returns>
        public static bool operator ==(StringEnumClass firstOperator, StringEnumClass secondOperator)
        {
            //If both are null, or both are the same instance, return true.
            if (ReferenceEquals(firstOperator, secondOperator))
            {
                return true;
            }

            //If one is null, but not both, return false.
            if ((object)firstOperator == null || (object)secondOperator == null)
            {
                return false;
            }

            //Return true if the fields match
            return (firstOperator._value == secondOperator._value);

        }

        /// <summary>
        /// Overloads operator !=
        /// </summary>
        /// <param name="firstOperator"></param>
        /// <param name="secondOperator"></param>
        /// <returns></returns>
        public static bool operator !=(StringEnumClass firstOperator, StringEnumClass secondOperator)
        {
            return !(firstOperator == secondOperator);
        }

        /// <summary>
        /// Implicit convert an instance of StringEnumClass to string value
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static implicit operator string(StringEnumClass p)
        {
            return p._value;
        }

        /// <summary>
        /// Override Equals() method. The function returns:
        /// - false: if the parameter is null or the parameter cannot be cast to StringEnumClass or the values not match.
        /// - true: if the values match.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            //If parameter is null, return false
            if (obj == null)
            {
                return false;
            }

            //If parameter cannot be cast to StringEnumClass, return false
            StringEnumClass p = obj as StringEnumClass;
            if ((System.Object)p == null)
            {
                return false;
            }

            //Return true if the values match
            return (_value == p._value);
        }

        /// <summary>
        /// The method return:
        /// - false: if parameter is null or the values not match
        /// - true: if the values match
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Equals(StringEnumClass p)
        {
            //Return fasle if parameter is null
            if ((object)p == null)
            {
                return false;
            }

            //Return true if the values match
            return (_value == p._value);
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
