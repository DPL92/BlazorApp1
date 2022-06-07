using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public  class Trip
    {
        public int tripId { get; set; }

        
        public Driver driver { get; set; }

        public int driverId { get; set; }
        public int startLId { get; set; }

        public int endLId { get; set; }


        public int vehicleId { get; set; }
       

        
        public Location startL { get; set; }
        
      
        public Location endL { get; set; }

        public int duration { get; set; }

        
       
        public Vehicle vehicle { get; set; }

      

        public bool finished { get; set; }

        public string date { get; set; }
    }
}
