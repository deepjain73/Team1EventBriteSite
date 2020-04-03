using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.ViewModels
{
    public class PaginatedEventsViewModel<TEntity>
        where TEntity : class // TEntity must be a reference type
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }
}
