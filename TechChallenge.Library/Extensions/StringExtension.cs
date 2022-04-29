using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Library.Extensions
{
    public static class StringExtension
    {
        public static List<T> ToList<T>(this string jsonContent)
        {
            if(string.IsNullOrEmpty(jsonContent))
                return new List<T>();

            var listContent = JsonConvert.DeserializeObject<List<T>>(jsonContent);
            
            if(listContent == null)
                return new List<T>();

            return listContent;
        }
    }
}
