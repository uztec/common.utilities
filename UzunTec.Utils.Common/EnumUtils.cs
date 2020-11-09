using System;
using System.Collections.Generic;

namespace UzunTec.Utils.Common
{
    public static class EnumUtils
    {
        public static IEnumerable<T> GetValues<T>() where T : struct, Enum
        {
            return (IEnumerable<T>)Enum.GetValues(typeof(T));
        }

        public static T? GetEnumValue<T>(object value, bool ignoreCase = true) where T : struct, Enum
        {
            try
            {
                return (value is string) ? ParseEnum<T>((string)value, ignoreCase)
                    : (T?)GetEnumInternalValue(typeof(T), value);
            }
            catch (InvalidCastException ex)
            {
                System.Diagnostics.Debug.Write(ex);
                return null;
            }
        }

        public static object GetEnumValue(Type enumType, object value, bool ignoreCase = true)
        {
            return (value is string) ? ParseEnum(enumType, (string)value, ignoreCase)
                    : GetEnumInternalValue(enumType, value);
        }

        public static T? ParseEnum<T>(string text, bool ignoreCase = true) where T : struct, Enum
        {
            return (Enum.TryParse<T>(text, ignoreCase, out T output)) ? (T?)output : null;
        }

        public static object ParseEnum(Type enumType, string text, bool ignoreCase = true)
        {
            try
            {
                return Enum.Parse(enumType, text, ignoreCase);
            }
            catch (ArgumentException ex)
            {
                System.Diagnostics.Debug.Write(ex);
                return null;
            }
        }

        private static object GetEnumInternalValue(Type enumType, object value)
        {
            try
            {
                object enumValue = Enum.ToObject(enumType, value);
                return (Enum.IsDefined(enumType, enumValue)) ? enumValue : null;
            }
            catch (InvalidCastException ex)
            {
                System.Diagnostics.Debug.Write(ex);
                return null;
            }
            catch (ArgumentException ex)
            {
                System.Diagnostics.Debug.Write(ex);
                return null;
            }
        }
    }
}
