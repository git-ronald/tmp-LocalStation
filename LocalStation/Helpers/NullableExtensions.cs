﻿namespace LocalStation.Helpers
{
    // TODO: shared library
    public static class NullableExtensions
    {
        public static TValue GetOrThrow<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TKey : notnull
        {
            return dictionary.GetOrThrow(key, $"Failed to read key {key}");
        }
        public static TValue GetOrThrow<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, string exceptionMessage) where TKey : notnull
        {
            return dictionary.GetOrThrow(key, () => new Exception(exceptionMessage));
        }
        public static TValue GetOrThrow<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<Exception> getException) where TKey : notnull
        {
            if (dictionary is null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (!dictionary.TryGetValue(key, out TValue? value))
            {
                throw getException();
            }
            if (value == null)
            {
                throw getException();
            }
            return value;
        }

        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue) where TKey : notnull
        {
            if (dictionary is null)
            {
                return defaultValue;
            }

            if (!dictionary.TryGetValue(key, out TValue? value))
            {
                return defaultValue;
            }
            return value;
        }

        public static Int32 ForceParseToInt(this string? value)
        {
            if (value is null)
            {
                return default;
            }

            try
            {
                return Int32.Parse(value);
            }
            catch
            {
                return default;
            }
        }

        public static string ForceToString(this object value)
        {
            if (value == null)
            {
                return String.Empty;
            }
            return value.ToString() ?? String.Empty;
        }
    }
}
