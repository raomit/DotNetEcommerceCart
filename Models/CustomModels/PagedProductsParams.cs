using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommCart.Models.CustomModels
{
    public class PagedProductsParams
    {
        public int start { get; set; }
        public int length { get; set; }
        public int draw { get; set; }
        public Search search { get; set; }
        public List<Ordering> order { get; set; }
        public List<Column> columns { get; set; }
        public class Column{
            public string data { get; set; }
            public string name { get; set; }
        }
        public class Ordering
        {
            public int column { get; set; }
            public string dir { get; set; }
        }

        public class Search
        {
            public string value { get; set; }
        }
    }
}