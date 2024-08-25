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
    public class tabelaAudiometriaController : ApiController
    {
        private WebTesteDB db = new WebTesteDB();

        //GET api/tabelaAudiometria
        public IEnumerable<tabelaAudiometria> GettabelaAudiometria()
        {
            return db.tabelaAudiometrias.AsEnumerable();
        }

        //GET api/tabelaAudiometria/5
        public tabelaAudiometria GetTabelaAudiometria(int id)
        {
            tabelaAudiometria audiometria = db.tabelaAudiometrias.Find(id);

            if (audiometria == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return audiometria;
        }

        //PUT api/tabelaAudiometria/5
        public HttpResponseMessage PuttabelaAudiometria(int id, tabelaAudiometria audiometria)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != audiometria.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(audiometria).State = EntityState.Modified;

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

        //POST api/tabelaAudiometria
        public HttpResponseMessage PosttabelaAudiometria(tabelaAudiometria audiometria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tabelaAudiometrias.Add(audiometria);
                    db.SaveChanges();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, audiometria);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = audiometria.id }));
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

        //DELETE api/tabelaAudiometria/5
        public HttpResponseMessage DeletetabelaAudiometria(int id)
        {
            tabelaAudiometria audiometria = db.tabelaAudiometrias.Find(id);

            if (audiometria == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.tabelaAudiometrias.Remove(audiometria);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, audiometria);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

}
