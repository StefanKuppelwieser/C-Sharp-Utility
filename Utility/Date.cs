using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// The class contains various conversions to the date and date data types
    /// </summary>
    public class Date
    {

        /// <summary>
        /// Formats the current date and time in a SQL-suitable format to save it directly into the database.
        /// </summary>
        /// <returns>Date as string for a SQL database that expects the type 'Date'</returns>
        public static string DateTimeForSQL()
        {
            // Get current date
            DateTime myDateTime = DateTime.Now;

            // Convert in correct format
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            return sqlFormattedDate;
        }

        /// <summary>
        /// Converts a date into the datetime typ
        /// </summary>
        /// <param name="dd">Describes the day</param>
        /// <param name="mm">Describes the month</param>
        /// <param name="yyyy">Describes the year</param>
        /// <returns>Return the date in datetime format</returns>
        public static DateTime ConvertDateToDatetime(string dd, string mm, string yyyy)
        {
            Boolean zustand = DateTime.TryParseExact(dd + "/" + mm + "/" + yyyy, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt);

            return (zustand == true ? dt : default(DateTime));
        }

        /// <summary>
        /// Converts a date into the datetime typ
        /// </summary>
        /// <param name="dd">Describes the day</param>
        /// <param name="mm">Describes the month</param>
        /// <param name="yyyy">Describes the year</param>
        /// <returns>Return the date in datetime format</returns>
        public static DateTime ConvertDateToDatetime(int dd, int mm, int yyyy)
        {
            Boolean zustand = DateTime.TryParseExact(dd + "/" + mm + "/" + yyyy, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt);

            return (zustand == true ? dt : default(DateTime));
        }

        /// <summary>
        /// It converts a date in type of string in type Dateime
        /// </summary>
        /// <param name="datetime">Contains the date as string</param>
        /// <returns>Return the date in type Datetime in Format 'yyyy-MM-dd HH:mm:ss.fff'</returns>
        public static DateTime ConvertStringToDatetime(string datetime)
        {
            DateTime myDate = default(DateTime);

            try
            {
                myDate = DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return myDate;
        }
    }
}
