using System;

namespace TgaCase.SharedKernel.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDateString(this DateTime str)
        {
            return str.ToString("dd.MM.yyyy");
        }
    }
}