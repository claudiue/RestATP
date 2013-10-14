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
    public class Vehicle
    {
        [Key]
        [StringLength(20)]
        [DataMember]
        public string VehicleID { get; set; }

        [StringLength(20)]
        [DataMember]
        public string Type { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Make { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }
    }
}