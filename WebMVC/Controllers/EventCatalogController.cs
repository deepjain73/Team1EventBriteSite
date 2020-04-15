using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventService _service;
        public EventCatalogController(IEventService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int ? page,int? typesFilterApplied,int? categoryFilterApplied)
        {
            var itemsOnPage = 10;

            var catalog = await _service.GetEventItemsAsync(page ?? 0, itemsOnPage,typesFilterApplied,categoryFilterApplied);
            var vm = new EventIndexViewModel
            {
                EventItems = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                Categories=await _service.GetCategoriesAsync(),
                Types=await _service.GetTypesAsync(),
                CategoryFilterApplied = categoryFilterApplied ?? 0,
                TypesFilterApplied = typesFilterApplied ?? 0
            };

            return View(vm);
        }
    }
}