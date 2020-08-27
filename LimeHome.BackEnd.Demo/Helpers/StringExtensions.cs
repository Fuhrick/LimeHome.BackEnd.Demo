using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimeHome.BackEnd.Demo.Helpers
{
    /// <summary>Provide string extension methods.</summary>
    public static class StringExtensions
    {
        /// <summary>Trims the specified string.</summary>
        /// <param name="value">The value to trim.</param>
        /// <param name="trimToNull"><c>true</c> to return <c>null</c> if the result of the trimming operation
        /// is an empty string; <c>false</c> to return an empty string.</param>
        /// <param name="normalizeWhitespace"><c>true</c> to normalize the string before trimming it.</param>
        /// <returns></returns>
        public static string TrimExt(this string value, bool trimToNull, bool normalizeWhitespace)
        {
            if (normalizeWhitespace)
                value = value.NormalizeWhitespace();
            value = !trimToNull ? value?.Trim() : value.TrimToNull();
            return value;
        }

        /// <summary>
        /// Trims the specified value and returns <c>null</c> if the result is an empty string.
        /// </summary>
        /// <param name="value">The value to trim.</param>
        /// <returns>A value without trailing or leading space or <c>null</c> if <paramref name="value" /> is
        /// <c>null</c>, an empty string or contains only whitespace.</returns>
        public static string TrimToNull(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return (string)null;
            value = value.Trim();
            if (value.Length != 0)
                return value;
            return (string)null;
        }

        /// <summary>
        /// Trims the specified value and replaces all whitespace and control character sequences (including '\t', '\r', '\b', etc.) with
        /// a single whitespace.
        /// </summary>
        /// <param name="value">The value to normalize.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// CAUTION This method does not return <c>null</c> in place of empty string values.
        /// </para>
        /// <para>
        /// Example: "  My name  \r\tis   John ! " will result in "My name is John!".
        /// </para>
        /// </remarks>
        public static string NormalizeWhitespace(this string value)
        {
            return value.NormalizeWhitespace(false);
        }

        /// <summary>
        /// Trims the specified value and replaces all whitespace and control character sequences (including '\t', '\r', '\b', etc.) with
        /// a single whitespace.
        /// </summary>
        /// <param name="value">The value to normalize.</param>
        /// <param name="preserveNewLine">Indicates if the new line "\n" character should be preserved.
        /// If <c>true</c> the new line character will be treated as a normal character and not a whitespace unless
        /// in the beginning or the end of the string (in which case it is treated as a whitespace character).</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// CAUTION This method does not return <c>null</c> in place of empty string values.
        /// </para>
        /// <para>
        /// Example: "  My name  \r\tis   John ! " will result in "My name is John!".
        /// </para>
        /// </remarks>
        public static string NormalizeWhitespace(this string value, bool preserveNewLine)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            bool flag = false;
            char[] array = (char[])null;
            int count = 0;
            for (int index = 0; index < value.Length; ++index)
            {
                char c = value[index];
                if ((char.IsWhiteSpace(c) || char.IsControl(c)) && (!preserveNewLine || c != '\n'))
                {
                    if (flag || c != ' ')
                    {
                        if (array == null)
                        {
                            array = new char[value.Length];
                            for (; count < index; ++count)
                                array[count] = value[count];
                        }
                        if (!flag)
                        {
                            flag = true;
                            array[count++] = ' ';
                        }
                    }
                    else
                    {
                        flag = true;
                        if (array != null)
                            array[count++] = ' ';
                    }
                }
                else
                {
                    flag = false;
                    if (array != null)
                        array[count++] = c;
                }
            }
            if (array == null)
                return value.Trim();
            Predicate<char> match = (Predicate<char>)(x =>
            {
                if (x != ' ')
                    return x != '\n';
                return false;
            });
            int startIndex1 = match(array[0]) ? 0 : Array.FindIndex<char>(array, 0, count, match);
            if (startIndex1 < 0)
                return string.Empty;
            int startIndex2 = count - 1;
            int num = match(array[startIndex2]) ? startIndex2 : Array.FindLastIndex<char>(array, startIndex2, match);
            return new string(array, startIndex1, num - startIndex1 + 1);
        }
    }
}
