using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogApi.Data;
using EventCatalogApi.Domain;
using EventCatalogApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCatalogController : ControllerBase
    {
        private readonly EventCatalogContext _context;
        private readonly IConfiguration _config;
        public EventCatalogController(EventCatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var itemsCount = await _context.EventItems.LongCountAsync();
            var items = await _context.EventItems
                .OrderBy(e=>e.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedEventsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/type/{eventTypeId}/category/{eventCategoryId}/location/{eventLocationId}/price/{eventPriceId}")]
        public async Task<IActionResult> Items(
            int eventTypeId,
            int eventcategoryId,
            int eventLocationId,
            int eventPriceId,
            [FromQuery]int pageIndex=0,
            [FromQuery]int pageSize=6)
        {
            var root = (IQueryable<EventItem>)_context.EventItems;
            if(eventTypeId > 0)
            {
                root = root.Where(e => e.EventTypeId == eventTypeId);
            }
            if (eventcategoryId >0)
            {
                root = root.Where(e => e.EventCategoryId == eventcategoryId);
            }
            if (eventLocationId > 0)
            {
                root = root.Where(e => e.EventLocationId == eventLocationId);
            }
            if (eventPriceId > 0)
            {
                root = root.Where(e => e.EventPriceId == eventPriceId);
            }


            var itemsCount = await root.LongCountAsync();
            var items = await root
                        .OrderBy(e => e.EventName)
                        .Skip(pageIndex * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedEventsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);
        }


        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(
                e => e.PictureUrl =
                e.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced",
                 _config["ExternalEventCatalogBaseUrl"])
                );
            return items;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var items = await _context.EventCategories.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var items = await _context.EventTypes.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var items = await _context.EventLocations.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventPrices()
        {
            var items = await _context.EventPrices.ToListAsync();
            return Ok(items);
        }

    }
}