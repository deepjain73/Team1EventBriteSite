using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class EventItem
    {
       
	public int Id { get; set; }
	public string EventName { get; set; }
	public string Description { get; set; }
	public string Venue { get; set; }
	public DateTime Date { get; set; }
	public decimal Price { get; set; }
	public string PictureUrl { get; set; }
	public int EventCategoryId { get; set; }
	public int EventTypeId { get; set; }
	public string EventCategory  { get; set; }
	public string EventType { get; set; }

	}
}
