using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestATP.Models
{
    public class ResponseSimple
    {
        public string URI { get; set; }
        public object Content { get; set; }
    }

    public class ResponseCompany
    {
        public string URI { get; set; }
        public object Content { get; set; }
        public string VehiclesURI { get; set; }
        public string RoutesURI { get; set; }
    }

    public class ResponseRoute
    {
        public string URI { get; set; }
        public object Content { get; set; }
        public string StopsURI { get; set; }
    }

    public class ResponseStop
    {
        public string URI { get; set; }
        public object Content { get; set; }
        public string RoutesURI { get; set; }
    }

    public class ResponseVehicle
    {
        public string URI { get; set; }
        public object Content { get; set; }
    }

}