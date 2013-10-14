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
    public class CompaniesController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        /// <summary>
        /// Gets the list of companies.
        /// </summary>
        public HttpResponseMessage Get()
        {
            IList<ResponseSimple> responses = new List<ResponseSimple>();
            var companies = unitOfWork.CompanyRepository.Get().ToList();

            foreach (var c in companies)
            {
                responses.Add(new ResponseSimple { Content = c, URI = string.Format("{0}/{1}", this.Request.RequestUri.AbsoluteUri, c.CompanyID)});
            }

            ResponseSimple response = new ResponseSimple() { Content = responses, URI = this.Request.RequestUri.AbsoluteUri };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public HttpResponseMessage Get(int id)
        {
            var company = unitOfWork.CompanyRepository.GetByID(id);
            ResponseCompany response = new ResponseCompany() 
            {
                URI = this.Request.RequestUri.AbsoluteUri,
                RoutesURI = string.Format("{0}/routes", this.Request.RequestUri.AbsoluteUri),
                VehiclesURI = string.Format("{0}/vehicles", this.Request.RequestUri.AbsoluteUri),
                Content = company
            };

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public HttpResponseMessage Post([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Not implemented.");
        }

        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Not implemented.");
        }

        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Not implemented.");
        }
    }
}
