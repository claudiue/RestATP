namespace RestATP.Migrations
{
    using RestATP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestATP.Repository.TransportContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RestATP.Repository.TransportContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            var companies = new List<Company>
            {
                new Company { Name = "RATP", Address = "Iasi", TicketPrice = 1.9},
                new Company { Name = "Unistil", Address = "Barlad", TicketPrice = 2.0}
            };

            var stops = new List<Stop>
            {
                new Stop { Name = "Rond Copou", Latitude = null, Longitude = null},
                new Stop { Name = "Stadion", Latitude = null, Longitude = null},
                new Stop { Name = "George Cosbuc", Latitude = null, Longitude = null},
                new Stop { Name = "Triumf", Latitude = null, Longitude = null},
            };

            var routes = new List<Route>
            {
                new Route { RouteID = "41", Name = "Rond Copou - Tehnopolis", Company = companies.ElementAt(0) },
                new Route { RouteID = "41b", Name = "Rond Copou - Blocuri Ciurea", Company = companies.ElementAt(0)},
                new Route { RouteID = "28", Name = "Triumf - Rond Dacia", Company = companies.ElementAt(0)},
                new Route { RouteID = "44", Name = "Rond Dacia - Tehnopolis", Company = companies.ElementAt(1)}
            };

            routes[0].Stops.Add(stops[0]);
            routes[0].Stops.Add(stops[1]);
            routes[0].Stops.Add(stops[2]);
            routes[0].Stops.Add(stops[3]);

            routes[1].Stops.Add(stops[0]);
            routes[1].Stops.Add(stops[1]);
            routes[1].Stops.Add(stops[2]);
            routes[1].Stops.Add(stops[3]);

            routes[2].Stops.Add(stops[3]);

            var vehicles = new List<Vehicle>
            {
                new Vehicle { VehicleID = "IS-01-RTP", Type = "Bus", Make = "Mercedes", Description = null, Company = companies.ElementAt(0)},
                new Vehicle { VehicleID = "IS-1245", Type = "Tram", Make = "Tatra", Description = null, Company = companies.ElementAt(0)}                
            };




            companies.ForEach(c => context.Companies.AddOrUpdate(r => r.Name, c));
            context.SaveChanges();

            stops.ForEach(s => context.Stops.AddOrUpdate(r => r.Name, s));
            context.SaveChanges();

            routes.ForEach(r => context.Routes.AddOrUpdate(r));
            context.SaveChanges();

            vehicles.ForEach(v => context.Vehicles.AddOrUpdate(v));
            context.SaveChanges();
        }
    }
}
