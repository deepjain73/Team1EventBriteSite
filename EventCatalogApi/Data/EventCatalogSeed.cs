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

        private static IEnumerable<EventItem> GetPreConfiguredEventItems()
        {
            return new List<EventItem>
            {
                new EventItem{EventCategoryId=1,EventTypeId=1,EventName="Ted Talks",Location="Bellevue",Date=new DateTime(2020,05,01,09,00,00), Description="Ideas worth Spreading", Price=20.00m, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem{EventCategoryId=1,EventTypeId=1,EventName="HTML Webinar",Location="Seattle",Date=new DateTime(2020,05,02,09,00,00), Description="KalAcademy presents, Intro to HTML", Price=50.00m, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/2"},
                new EventItem{EventCategoryId=2,EventTypeId=1,EventName="Cooking With Dad", Location="Redmond", Date=new DateTime(2020,05,03,09,00,00), Description="Have fun while cooking with kids",Price=35.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/3"},
                new EventItem{EventCategoryId=2, EventTypeId=1,EventName="Parent Seminar", Location="Seattle", Date=new DateTime(2020,05,04,09,00,00),Description="What about the Children",Price=0.0m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/4"},
                new EventItem{EventCategoryId=2, EventTypeId=1, EventName="Kids Tech MeetUp",Location="Bellevue", Date= new DateTime(2020,05,05,09,00,00), Description="Discuss Technology Product for Children",Price=30.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem{EventCategoryId=1,EventTypeId=2,EventName="Business Networking Party",Location="Tacoma",Date= new DateTime(2020,05,06,13,00,00),Description="Business Meetup and Lunch",Price=50.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/6"},
                new EventItem{EventCategoryId=1,EventTypeId=2,EventName="Product Launch ",Location="Seattle",Date= new DateTime(2020,05,07,09,00,00),Description="Tech Product launch",Price=00.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/7"},
                new EventItem{EventCategoryId=3,EventTypeId=2,EventName="Holi Party",Location="Sammamish",Date= new DateTime(2020,05,08,11,00,00),Description="Join us for Holi Celebration",Price=15.00m,PictureUrl="http://externalcatalogbaseurltobere15aced/api/pic/8"},
                new EventItem{EventCategoryId=3,EventTypeId=2,EventName="Senior Get Together",Location="Seattle",Date= new DateTime(2020,05,09,11,00,00),Description="A Guide to staying connected and making Friends",Price=00.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/9"},
                new EventItem{EventCategoryId=2,EventTypeId=3,EventName="One day Family Cruise",Location="Seattle",Date= new DateTime(2020,05,10,09,00,00),Description="Dance,Sing, Eat and have fun with family on the Cruise",Price=75.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/10"},
                new EventItem{EventCategoryId=2,EventTypeId=3,EventName="Pacific Science Center Tour",Location="Seattle",Date= new DateTime(2020,05,11,09,00,00),Description="Enjoy hands-on science exhibits and activities",Price=30.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/11"},
                new EventItem{EventCategoryId=2,EventTypeId=3,EventName="Museum of Flight Tour",Location="Seattle",Date= new DateTime(2020,05,12,09,00,00),Description="A Great place to bring the Kids",Price=30.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/12"},
                new EventItem{EventCategoryId=4,EventTypeId=4,EventName="Zumba Dance WorkOut",Location="Bellevue",Date= new DateTime(2020,05,13,09,00,00),Description="Dance Workout for weight loss",Price=15.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/13"},
                new EventItem{EventCategoryId=4,EventTypeId=4,EventName="5K Run",Location="Seattle",Date= new DateTime(2020,05,14,09,00,00),Description="5K Friend and Family Run",Price=00.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/14"},
                new EventItem{EventCategoryId=4,EventTypeId=4,EventName="Grow your Own",Location="Redmond",Date= new DateTime(2020,05,15,10,00,00),Description="Learn to grow your own Vegetables",Price=50.00m,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/150-"},
            };
        }
    }
}
