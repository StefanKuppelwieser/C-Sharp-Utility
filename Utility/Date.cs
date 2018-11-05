using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// The class contains various conversions to the date and date data types
    /// </summary>
    class Date
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

    }
}
