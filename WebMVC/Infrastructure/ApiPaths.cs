using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPaths
    {
        public static class Event
        {
            public static string GetAllEventItems(string baseUri, int page, int take,int? type,int? category)
            {
                var filterQs = string.Empty;
                if(type.HasValue || category.HasValue)
                {
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : "0";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "0";
                    filterQs = $"/type/{typeQs}/category/{categoryQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }

            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}eventcategories";
            }
        }
    }
}
