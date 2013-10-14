using RestATP.Models;
using RestATP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestATP.Controllers
{
    public class VehiclesController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/company
        public HttpResponseMessage Get()
        {
            IList<ResponseSimple> responses = new List<ResponseSimple>();
            var vehicles = unitOfWork.VehicleRepository.Get().ToList();

            foreach (var v in vehicles)
            {
                responses.Add(new ResponseSimple { Content = v, URI = string.Format("{0}/{1}", this.Request.RequestUri.AbsoluteUri, v.VehicleID) });
            }

            ResponseSimple response = new ResponseSimple() { Content = responses, URI = this.Request.RequestUri.AbsoluteUri };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET api/vehicle/5
        public HttpResponseMessage Get(string id)
        {
            var vehicle = unitOfWork.VehicleRepository.GetByID(id);
            ResponseVehicle response = new ResponseVehicle()
            {
                URI = this.Request.RequestUri.AbsoluteUri,
                Content = vehicle
            };

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpPost]
        public object Post([FromBody] Vehicle value)
        {
            if(value == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No body content found!");
            }
            if(string.IsNullOrEmpty(value.VehicleID) || string.IsNullOrWhiteSpace(value.VehicleID))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No VehicleID found!");
            }

            if (value.CompanyID == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "CompanyID is null!");
            }
            if(unitOfWork.CompanyRepository.GetByID(value.CompanyID) == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no company with this ID!");
            }

            var maybe = unitOfWork.VehicleRepository.GetByID(value.VehicleID);
            if(maybe != null)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, "VehicleID confliect! There is already a vehicle with this ID!");
            }

            value.Company = unitOfWork.CompanyRepository.GetByID(value.CompanyID);
            try
            {
                unitOfWork.VehicleRepository.Insert(value);
                unitOfWork.Save();
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            ResponseSimple response = new ResponseSimple()
            {
                URI =  string.Format("{0}/{1}", this.Request.RequestUri.AbsoluteUri, value.VehicleID),
                Content = unitOfWork.VehicleRepository.GetByID(value.VehicleID)
            };

            return Request.CreateResponse(HttpStatusCode.Created, response);
        }


        [HttpPut]
        public object Put(string id, [FromBody] Vehicle value)
        {
            if (value == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No body content found!");
            }
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No VehicleID found!");
            }

            if (value.CompanyID != null)
            {
                if(unitOfWork.CompanyRepository.GetByID(value.CompanyID) == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no company with this ID!");
                }
            }

            value.VehicleID = id;
            var company = unitOfWork.CompanyRepository.GetByID(value.CompanyID);
            value.Company = company;
          
            try
            {
                unitOfWork.VehicleRepository.Update(value);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // DELETE api/vehicle/5
        public object Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No VehicleID found!");
            }

            try
            {
                unitOfWork.VehicleRepository.Delete(id);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
