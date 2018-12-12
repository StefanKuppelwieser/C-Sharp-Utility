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
    public class Type
    {

        /// <summary>
        /// It converts a number of type String to type Int. If the String is empty or an error ocurred it will return the value '0'.
        /// </summary>
        /// <param name="numberAsString">A number of type String.</param>
        /// <param name="numberAsString">A number of type String.</param>
        /// <returns>A number of type Int.</returns>
        public static int ConvertStringToInt(String numberAsString)
        {
            int number = 0;

            if (IsStringEmpty(numberAsString))
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
        /// It converts a number of type String to type Double. If the String is empty or an error ocurred it will return the value ''.
        /// </summary>
        /// <param name="numberAsString">A number of type String.</param>
        /// <returns>A number of type Double.</returns>
        public static double ConvertStringToDouble(String doubleAsString)
        {
            double number = 0.0;

            if (IsStringEmpty(doubleAsString))
            {
                return number;
            }

            try
            {
                // Replace
                doubleAsString = doubleAsString.Replace(".", ",");
                // Convert
                number = Double.Parse(doubleAsString);
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
        public static Boolean IsStringEmpty(String value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length == 0 || value == String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Convert a point of the data type. System.Windows.Point to System.Drawing.Point
        /// </summary>
        /// <param name="point">Contains the coordinate of type System.Windows.Point</param>
        /// <returns>Returns a point of the System.Drawing.Point data type</returns>
        public static System.Drawing.Point ConvertWindowsPointToDrawingPoint(System.Windows.Point point)
        {
            System.Drawing.Point newPoint = new System.Drawing.Point();

            newPoint.X = Convert.ToInt32(point.X);
            newPoint.Y = Convert.ToInt32(point.Y);

            return newPoint;
        }

        /// <summary>
        /// Checks if the entered number is an even number
        /// </summary>
        /// <param name="number"> Contains the number to be checked </ param>
        /// <returns>Returns true if the number is even </ returns>
        private static bool isModulo(int number)
        {
            return number % 2 == 0;
        }
    }
}
