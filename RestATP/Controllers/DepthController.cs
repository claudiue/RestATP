using RestATP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestATP.Controllers
{
    public class DepthController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpGet]
        public HttpResponseMessage GetRoutesByCompanyID(int companyid)
        {
            var routes = unitOfWork.RouteRepository.Get(r => r.CompanyID == companyid);
            return Request.CreateResponse(HttpStatusCode.OK, routes);
        }

        //[HttpGet]
        //public HttpResponseMessage GetRoutesByCompanyID(int companyid, string id)
        //{
        //    var routes = unitOfWork.RouteRepository.Get(r => r.CompanyID == companyid);
        //    return Request.CreateResponse(HttpStatusCode.OK, routes.Where(r => r.RouteID == id));
        //}

        [HttpGet]
        public HttpResponseMessage GetVehiclesByCompanyID(int companyid)
        {
            var vehicles = unitOfWork.VehicleRepository.Get(v => v.CompanyID == companyid);
            return Request.CreateResponse(HttpStatusCode.OK, vehicles);
        }

        //[HttpGet]
        //public HttpResponseMessage GetVehiclesByCompanyID(int companyid, string id)
        //{
        //    var vehicles = unitOfWork.VehicleRepository.Get(v => v.CompanyID == companyid);
        //    return Request.CreateResponse(HttpStatusCode.OK, vehicles.Where(v => v.VehicleID == id));
        //}

        [HttpGet]
        public HttpResponseMessage GetRoutesByStopID(int id)
        {
            var stop = unitOfWork.StopRepository.Get(r => r.StopID == id);
            var stopRoutes = stop.SelectMany(r => r.Routes);
            return Request.CreateResponse(HttpStatusCode.OK, stopRoutes);
        }

        [HttpGet]
        public HttpResponseMessage GetStopsByRouteID(string id)
        {
            var route = unitOfWork.RouteRepository.Get(r => r.RouteID == id);
            var routeStops = route.SelectMany(r => r.Stops);
            return Request.CreateResponse(HttpStatusCode.OK, routeStops);
        }

    }
}
