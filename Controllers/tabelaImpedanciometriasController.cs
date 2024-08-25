using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using webTesteAPI.Models;

namespace webTesteAPI.Controllers
{
    public class tabelaImpedanciometriaController : ApiController
    {
        private WebTesteDB db = new WebTesteDB();

        //GET api/tabelaImpedanciometria
        public IEnumerable<tabelaImpedanciometria> GettabelaImpedanciometria()
        {
            return db.tabelaImpedanciometrias.AsEnumerable();
        }

        //GET api/tabelaImpedanciometria/5
        public tabelaImpedanciometria GetTabelaImpedanciometria(int id)
        {
            tabelaImpedanciometria impedanciometria = db.tabelaImpedanciometrias.Find(id);

            if (impedanciometria == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return impedanciometria;
        }

        //PUT api/tabelaImpedanciometria/5
        public HttpResponseMessage PuttabelaImpedanciometria(int id, tabelaImpedanciometria impedanciometria)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != impedanciometria.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(impedanciometria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //POST api/tabelaImpedanciometria
        public HttpResponseMessage PosttabelaImpedanciometria(tabelaImpedanciometria impedanciometria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tabelaImpedanciometrias.Add(impedanciometria);
                    db.SaveChanges();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, impedanciometria);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = impedanciometria.id }));
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DELETE api/tabelaImpedanciometria/5
        public HttpResponseMessage DeletetabelaImpedanciometria(int id)
        {
            tabelaImpedanciometria impedanciometria = db.tabelaImpedanciometrias.Find(id);

            if (impedanciometria == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.tabelaImpedanciometrias.Remove(impedanciometria);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, impedanciometria);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

}
