using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IEventService
    {
        Task<Event> GetEventItemsAsync(int page, int size,int? type,int? category, int?location,int?price);
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetTypesAsync();
        Task<IEnumerable<SelectListItem>> GetLocationsAsync();
        Task<IEnumerable<SelectListItem>> GetPricesAsync();


    }
}
