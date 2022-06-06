using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class Location
    {
        public int locationId  { get; set; }
        public string locationName { get; set; }
        public string country { get; set; }

        public int postalCode { get; set; }

        public string street { get; set; }

        public int houseNr { get; set; }


    }
}
