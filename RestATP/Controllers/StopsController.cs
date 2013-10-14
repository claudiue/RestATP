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
    public class StopsController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/company
        public HttpResponseMessage Get()
        {
            IList<ResponseSimple> responses = new List<ResponseSimple>();
            var stops = unitOfWork.StopRepository.Get().ToList();

            foreach (var s in stops)
            {
                responses.Add(new ResponseSimple { Content = s, URI = string.Format("{0}/{1}", this.Request.RequestUri.AbsoluteUri, s.StopID) });
            }

            ResponseSimple response = new ResponseSimple() { Content = responses, URI = this.Request.RequestUri.AbsoluteUri };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET api/stop/5
        public HttpResponseMessage Get(int id)
        {
            var stop = unitOfWork.StopRepository.GetByID(id);
            ResponseStop response = new ResponseStop()
            {
                URI = this.Request.RequestUri.AbsoluteUri,
                RoutesURI = string.Format("{0}/routes", this.Request.RequestUri.AbsoluteUri),
                Content = stop
            };

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST api/stop
        public HttpResponseMessage Post([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Not implemented.");
        }

        // PUT api/stop/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Not implemented.");
        }

        // DELETE api/stop/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Not implemented.");
        }
    }
}
