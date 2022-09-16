using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace OnlineShop.Common.Extensions
{
    public static class ConfigurationExtension
    {
        public static IDictionary<string, T> GetObject<T>(this IConfiguration configuration, params string[] objectKey)
        {
            var configs = new Dictionary<string, T>();
            foreach (var key in objectKey)
            {
                var config = configuration.GetSection(key).Get<T>();
                if (config == null)
                    throw new InvalidOperationException($"There is no {key} option on configurations file");

                configs.Add(key, config);
            }

            return configs;
        }

        public static IDictionary<string, T> GetObject<T>(this IConfiguration configuration, params (string key, Type type)[] obj)
        {
            var configs = new Dictionary<string, T>();
            foreach (var val in obj)
            {
                // throw if val.type not class/subclass of type T
                if (!val.type.IsAssignableFrom(typeof(T)) && !val.type.IsSubclassOf(typeof(T)))
                    throw new InvalidOperationException($"Type {val.type} is not part of {typeof(T)}");

                var config = configuration.GetSection(val.key).Get(val.type);
                if (config == null)
                    throw new InvalidOperationException($"There is no {val} option on configurations file");

                configs.Add(val.key, (T)config);
            }

            return configs;
        }
    }
}