using EventCatalogApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EventCatalogApi.Data
{
    public static class EventCatalogSeed
    {
        public static void Seed(EventCatalogContext context)
        {
            context.Database.Migrate();
            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetPreConfiguredEventCategories());
                context.SaveChanges();
            }

            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetPreConfiguredEventTypes());
                context.SaveChanges();
            }
            if (!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(GetPreConfiguredEventLocations());
                context.SaveChanges();
            }
            if (!context.EventPrices.Any())
            {
                context.EventPrices.AddRange(GetPreConfiguredEventPrices());
                context.SaveChanges();
            }

            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetPreConfiguredEventItems());
                context.SaveChanges();
            }
        }



        private static IEnumerable<EventType> GetPreConfiguredEventTypes()
        {
            return new List<EventType>
            {
                new EventType{Type="Classes and Conference"},
                new EventType{Type="Dinner and Party"},
                new EventType{Type="Tour and Attraction"},
                new EventType{Type="Others"}
            };
        }

        private static IEnumerable<EventCategory> GetPreConfiguredEventCategories()
        {
            return new List<EventCategory>
            {
                new EventCategory{ Category= "Business and Professional"},
                new EventCategory{ Category="Family and Education"},
                new EventCategory{ Category=" Community and Culture" },
                new EventCategory{ Category="Others"}
            };

        }
        private static IEnumerable<EventLocation> GetPreConfiguredEventLocations()
        {
            return new List<EventLocation>
            {
                new EventLocation{ Location= "Bellevue"},
                new EventLocation{ Location= "Seattle"},
                new EventLocation{ Location= "Redmond"},
                new EventLocation{ Location= "Tacoma"},
                new EventLocation{ Location= "Sammamish"},
            };
        }

        private static IEnumerable<EventPrice> GetPreConfiguredEventPrices()
        {
            return new List<EventPrice>
            {
                new EventPrice{ eventPrice= "Free"},
                new EventPrice{ eventPrice= "Paid"},
               
            };

        }

        private static IEnumerable<EventItem> GetPreConfiguredEventItems()
        {
            return new List<EventItem>
            {
                new EventItem{EventCategoryId=1,EventTypeId=1,EventLocationId=1,EventPriceId=2,EventName="Ted Talks",Date=new DateTime(2020,05,01,09,00,00),Description="Ideas worth Spreading",Venue="Bellevue Downtown,Bellevue,WA", Price=20.00m,PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem{EventCategoryId=1,EventTypeId=1,EventLocationId=2,EventPriceId=2,EventName="HTML Webinar",Date=new DateTime(2020,05,02,09,00,00),Description="KalAcademy presents, Intro to HTML",Venue="Seattle Downtown,Seattle,WA",Price=50.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/2"},
                new EventItem{EventCategoryId=2,EventTypeId=1,EventLocationId=3,EventPriceId=2,EventName="Cooking With Dad",Date=new DateTime(2020,05,03,09,00,00),Description="Have fun while cooking with kids",Venue="Redmond Downtown,Redmond,WA",Price=35.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/3"},
                new EventItem{EventCategoryId=2, EventTypeId=1,EventLocationId=2,EventPriceId=1,EventName="Parent Seminar",Date=new DateTime(2020,05,04,09,00,00),Description="What about the Children",Venue="Seattle Downtown,Seattle,WA",Price=0.0m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/4"},
                new EventItem{EventCategoryId=2, EventTypeId=1,EventLocationId=1,EventPriceId=2,EventName="Kids Tech MeetUp",Date= new DateTime(2020,05,05,09,00,00),Description="Discuss Technology Product for Children",Venue="Bellevue Downtown,Bellevue,WA",Price=30.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem{EventCategoryId=1,EventTypeId=2,EventLocationId=4,EventPriceId=2,EventName="Business Networking Party",Date= new DateTime(2020,05,06,13,00,00),Description="Business Meetup and Lunch",Venue="Tacoma Downtown,Tacoma,WA",Price=50.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/6"},
                new EventItem{EventCategoryId=1,EventTypeId=2,EventLocationId=2,EventPriceId=1,EventName="Product Launch ",Date= new DateTime(2020,05,07,09,00,00),Description="Tech Product launch",Venue="Sattle Downtown,Seattle,WA",Price=00.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/7"},
                new EventItem{EventCategoryId=3,EventTypeId=2,EventLocationId=5,EventPriceId=2,EventName="Holi Party",Date= new DateTime(2020,05,08,11,00,00),Description="Join us for Holi Celebration",Venue="Sammamish State Park,Sammamish,WA",Price=15.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/8"},
                new EventItem{EventCategoryId=3,EventTypeId=2,EventLocationId=2,EventPriceId=1,EventName="Senior Get Together",Date= new DateTime(2020,05,09,11,00,00),Description="A Guide to staying connected and making Friends",Venue="Seattle Downtown,Seattle,WA",Price=00.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/9"},
                new EventItem{EventCategoryId=2,EventTypeId=3,EventLocationId=2,EventPriceId=2,EventName="One day Family Cruise",Date= new DateTime(2020,05,10,09,00,00),Description="Dance,Sing, Eat and have fun with family on the Cruise",Venue="Port of Seattle,Seattle,WA",Price=75.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/10"},
                new EventItem{EventCategoryId=2,EventTypeId=3,EventLocationId=2,EventPriceId=2,EventName="Pacific Science Center Tour",Date= new DateTime(2020,05,11,09,00,00),Description="Enjoy hands-on science exhibits and activities",Venue="Pacific Sceience Center,Seattle,WA",Price=30.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/11"},
                new EventItem{EventCategoryId=2,EventTypeId=3,EventLocationId=2,EventPriceId=2,EventName="Museum of Flight Tour",Date= new DateTime(2020,05,12,09,00,00),Description="A Great place to bring the Kids",Venue="Marginal Way,Seattle,WA",Price=30.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/12"},
                new EventItem{EventCategoryId=4,EventTypeId=4,EventLocationId=2,EventPriceId=2,EventName="Zumba Dance WorkOut",Date= new DateTime(2020,05,13,09,00,00),Description="Dance Workout for weight loss",Venue="YMCA,Bellevue,WA",Price=15.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/13"},
                new EventItem{EventCategoryId=4,EventTypeId=4,EventLocationId=2,EventPriceId=1,EventName="5K Run",Date= new DateTime(2020,05,14,09,00,00),Description="5K Friend and Family Run",Venue="Seattle Downtown,Seattle,WA",Price=00.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/14"},
                new EventItem{EventCategoryId=4,EventTypeId=4,EventLocationId=3,EventPriceId=2,EventName="Grow your Own",Date= new DateTime(2020,05,15,10,00,00),Description="Learn to grow your own Vegetables",Venue="Redmond Downtown,Redmond,WA",Price=50.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/15"}
            };
        }
    }
}
