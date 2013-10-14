using RestATP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RestATP.Repository
{
    public class TransportContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Stop> Stops { get; set; }

        public TransportContext() : base ("TransportContext")
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Route>()
                .HasMany(r => r.Stops).WithMany(s => s.Routes)
                .Map(t => t.MapLeftKey("RouteID")
                    .MapRightKey("StopID")
                    .ToTable("RouteStop"));
            //modelBuilder.Entity<Route>().HasOptional(r => r.Company);
            

            //modelBuilder.Entity<Company>().HasMany(c => c.Vehicles);
            //modelBuilder.Entity<Company>().HasMany(c => c.Routes);

            //modelBuilder.Entity<Vehicle>().HasOptional(c => c.Company);
        }
    }
}