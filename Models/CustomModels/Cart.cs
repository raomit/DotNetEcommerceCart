using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommCart.Models.CustomModels
{
    public class Cart
    {
        public int totalItems {  get; set; }

        public Dictionary<string, Product> products { get; set; }

        public class Product
        {
            public int productId {  get; set; }
            public int quantity { get; set; }
            public int productPrice { get; set; }
        }
    }
}