using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// The Type class contains methods that deal with the common common data types. It will mainly contain conversions and reviews.
    /// </summary>
    class Type
    {

        /// <summary>
        /// It converts a number of type String to type Int. If the String is empty or an error ocurred it  will return the value '-1'.
        /// </summary>
        /// <param name="numberAsString">A number of type String.</param>
        /// <returns>A number of type Int.</returns>
        public static int ConvertStringToInt(String numberAsString)
        {
            int number = -1;

            if (isStringEmpty(numberAsString))
            {
                return number;
            }

            try
            { 
                number = Int32.Parse(numberAsString);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return number;
        }

        /// <summary>
        /// It checks to see if the string is empty or not. If it is true will be given back.
        /// </summary>
        /// <param name="value">An string.</param>
        /// <returns>If the string is empty it will return true otherwise false.</returns>
        public static Boolean isStringEmpty(String value)
        {
            if(value.Length == 0 || value == String.Empty || value == null)
            {
                return true;
            } else
            {
                return false;
            }
        }

    }
}
