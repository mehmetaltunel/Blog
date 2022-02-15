using System;

namespace Blog.SharedKernel.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDateString(this DateTime str)
        {
            return str.ToString("dd.MM.yyyy");
        }
    }
}