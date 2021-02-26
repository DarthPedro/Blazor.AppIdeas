using System;
using System.Collections.Generic;

namespace Blazor.AppIdeas.Converters.Pages
{
    public static class HtmlFormatHelper
    {
        public static IEnumerable<Tuple<string, TValue>> GetEnumData<TValue>()
            where TValue : Enum
        {
            var list = new List<Tuple<string, TValue>>();
            foreach (TValue value in Enum.GetValues(typeof(TValue)))
            {
                list.Add(new Tuple<string, TValue>(value.ToString(), value));
            }

            return list;
        }
    }
}
