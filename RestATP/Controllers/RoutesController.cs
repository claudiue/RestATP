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
    public class RoutesController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/company
        public HttpResponseMessage Get()
        {
            IList<ResponseSimple> responses = new List<ResponseSimple>();
            var routes = unitOfWork.RouteRepository.Get();

            foreach (var r in routes)
            {
                responses.Add(new ResponseSimple { Content = r, URI = string.Format("{0}/{1}", this.Request.RequestUri.AbsoluteUri, r.RouteID) });
            }

            ResponseSimple response = new ResponseSimple() { Content = responses, URI = this.Request.RequestUri.AbsoluteUri };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET api/route/5
        public HttpResponseMessage Get(string id)
        {
            var route = unitOfWork.RouteRepository.GetByID(id);
            ResponseRoute response = new ResponseRoute()
            {
                URI = this.Request.RequestUri.AbsoluteUri,
                StopsURI = string.Format("{0}/stops", this.Request.RequestUri.AbsoluteUri),
                Content = route
            };

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST api/route
        public HttpResponseMessage Post([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Not implemented.");
        }

        // PUT api/route/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Not implemented.");
        }

        // DELETE api/route/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Not implemented.");
        }
    }
}
