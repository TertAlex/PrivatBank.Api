using System;

namespace Sentinelab.PrivatBank.Api.Extensions
{
    internal static class DateTimeExtensions
    {
        /// <summary>
        ///     Converts to dot separated format 'dd.mm.yyyy'. Example: '11.08.2013'.
        ///     Reference <https://en.wikipedia.org/wiki/Date_and_time_notation_in_Europe>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDotFormatString(this DateTime dateTime)
        {
            return $"{dateTime.Day:d2}.{dateTime.Month:d2}.{dateTime.Year}";
        }
    }
}