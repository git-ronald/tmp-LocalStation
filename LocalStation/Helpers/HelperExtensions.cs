using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStation.Helpers
{
    // TODO: shared library
    public static class HelperExtensions
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
    }
}
