using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventService _service;
        public EventCatalogController(IEventService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int page)
        {
            var itemsOnPage = 10;
            var catalog = await _service.GetEventItemsAsync(page, itemsOnPage);
            return View(catalog);
        }
    }
}