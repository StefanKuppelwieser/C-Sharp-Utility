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
            DateTime dt;

            DateTime.TryParseExact(dd + "/" + mm + "/" + yyyy, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

            return dt;
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
            DateTime dt;

            DateTime.TryParseExact(dd + "/" + mm + "/" + yyyy, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

            return dt;
        }
    }
}
