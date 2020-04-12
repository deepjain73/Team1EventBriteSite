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
            public static string GetAllEventItems(string baseUri, int page, int take)
            {
                return $"{baseUri}items?pageIndex={page}&pageSize={take}";
            }
        }
    }
}
