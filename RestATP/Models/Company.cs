using RestATP.Repository;
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
    public class Company
    {
        public Company()
        {
            Routes = new HashSet<Route>();
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        [DataMember]
        public int CompanyID { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Name { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public double TicketPrice { get; set; }
        
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}