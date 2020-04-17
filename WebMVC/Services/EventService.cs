using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUri;
        private readonly IHttpClient _client;
        public EventService(IConfiguration config,IHttpClient client)
        {
            _baseUri = $"{config["EventUrl"]}/api/eventcatalog/";
            _client = client;
        }       

        public async Task<Event> GetEventItemsAsync(int page, int size,int? type,int? category, int? location, int? price)
        {
            var eventItemsUri= ApiPaths.Event.GetAllEventItems(_baseUri,page,size,type,category,location,price);
            var dataString=await _client.GetStringAsync(eventItemsUri);
            return JsonConvert.DeserializeObject<Event>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categoryUri = ApiPaths.Event.GetAllCategories(_baseUri);
            var dataString=await _client.GetStringAsync(categoryUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="All",
                    Value=null,
                    Selected=true
                }
            };
            var categories = JArray.Parse(dataString);
            foreach (var category in categories)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = category.Value<string>("id"),
                        Text = category.Value<string>("category")
                    });
            }
            return items;
        }
        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri=ApiPaths.Event.GetAllTypes(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="All",
                    Value=null,
                    Selected=true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text=type.Value<string>("type")
                    });
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
        {
            var typeUri = ApiPaths.Event.GetAllLocations(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="All",
                    Value=null,
                    Selected=true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("location")
                    });
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetPricesAsync()
        {
            var typeUri = ApiPaths.Event.GetAllPrices(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="All",
                    Value=null,
                    Selected=true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {

                string output = type.Value<string>("eventPrice");
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = output
                    });
            }
            return items;
        }
    }
}
