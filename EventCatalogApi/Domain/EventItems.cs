using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Domain
{
    public class EventItems
    {
       
	public int Id { get; set; }
	public string EventName { get; set; }
	public string Description { get; set; }
	public string Location { get; set; }
	public DateTime Date { get; set; }
	public decimal Price { get; set; }
	public string PictureUrl { get; set; }
	public int EventCategoryId { get; set; }
	public int EventTypeId { get; set; }
	public virtual EventCategory EventCategory { get; set; }
	public virtual EventType EventType { get; set; }

	}
}
