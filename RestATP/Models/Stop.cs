using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestATP.Models
{
    [DataContract]
    public class Stop
    {
        public Stop()
        {
            Routes = new HashSet<Route>();
        }
        
        [Key]
        [DataMember]
        public int StopID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double? Latitude { get; set; }

        [DataMember]
        public double? Longitude { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}