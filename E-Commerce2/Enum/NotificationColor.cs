using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce2.Enum
{
    public enum NotificationColor
    {
        error,
        success,
        warning,
        danger
    }

    public static class ErrorLevelExtensions
    {
        /// <summary>
        /// Get Color Name
        /// </summary>
        /// <param name="jsonColor"></param>
        /// <returns>string</returns>
        public static string ToColorName(this NotificationColor jsonColor) => jsonColor.ToString().ToLower();
    }
}
