using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CartApi.Models
{
    public class Cart
    {
        public string BuyerID { get; set; }
        public List<CartItem> Items { get; set; }

        public Cart()
        { }

        public Cart(string cartId)
        {
            BuyerID = cartId;
            Items = new List<CartItem>  ();
        }
    }
}
