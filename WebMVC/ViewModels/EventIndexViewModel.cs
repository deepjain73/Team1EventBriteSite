using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.ViewModels
{
    public class EventIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<SelectListItem> Type { get; set; }
        public IEnumerable<EventItem> EventItems { get; set; }

        //public int? CategoryFilterApplied { get; set; }
        //public int? TypesFilterApplied { get; set; }

    }
}
