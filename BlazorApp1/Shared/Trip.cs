using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public  class Trip
    {
        public int tripId { get; set; }

        //[ForeignKey("driverId")]
        public Driver driver { get; set; }

        public int driverId { get; set; }
        public int startId { get; set; }

        public int endId { get; set; }


        public int vehicleId { get; set; }
        //[ForeignKey("startId")]
        public Location startL { get; set; }
       // [ForeignKey("endId")]

        public Location endL { get; set; }

        public double duration { get; set; }

        //[ForeignKey("vehicleId")]

        public Vehicle vehicle { get; set; }

      

        public bool finished { get; set; }

        public string date { get; set; }
    }
}
