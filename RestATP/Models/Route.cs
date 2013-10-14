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
    public class Route
    {
        public Route()
        {
            Stops = new HashSet<Stop>();
        }

        [Key]
        [DataMember]
        public string RouteID { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }

        [DataMember]
        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Stop> Stops { get; set; }
    }
}