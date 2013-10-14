using RestATP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestATP.Repository
{
    public class UnitOfWork : IDisposable
    {
        private Repository.TransportContext context = new Repository.TransportContext();
        private GenericRepository<Company> companyRepository;
        private GenericRepository<Route> routeRepository;
        private GenericRepository<Stop> stopRepository;
        private GenericRepository<Vehicle> vehicleRepository;


        public GenericRepository<Company> CompanyRepository
        {
            get
            {

                if (this.companyRepository == null)
                {
                    this.companyRepository = new GenericRepository<Company>(context);
                }
                return companyRepository;
            }
        }

        public GenericRepository<Route> RouteRepository 
        {
            get
            {

                if (this.routeRepository == null)
                {
                    this.routeRepository = new GenericRepository<Route>(context);
                }
                return routeRepository;
            }
        }

        public GenericRepository<Stop> StopRepository
        {
            get
            {

                if (this.stopRepository == null)
                {
                    this.stopRepository = new GenericRepository<Stop>(context);
                }
                return stopRepository;
            }
        }

        public GenericRepository<Vehicle> VehicleRepository
        {
            get
            {

                if (this.vehicleRepository == null)
                {
                    this.vehicleRepository = new GenericRepository<Vehicle>(context);
                }
                return vehicleRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}