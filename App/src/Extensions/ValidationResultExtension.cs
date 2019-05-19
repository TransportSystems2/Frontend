using System;
using System.Collections.Generic;
using MvvmValidation;

namespace TransportSystems.Frontend.App.Extensions
{
    public static class ValidationResultExtension
    {
        public static Dictionary<string, string> AsErrorDictionary(this ValidationResult result)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var item in result.ErrorList)
            {
                var key = item.Target.ToString();
                var text = item.ErrorText;
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key] = dictionary.Keys + Environment.NewLine + text;
                }
                else
                {
                    dictionary[key] = text;
                }
            }
            return dictionary;
        }
    }
}