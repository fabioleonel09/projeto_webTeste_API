using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using webTesteAPI.Models;

namespace webTesteAPI.Controllers
{
    public class tabelaPacientesController : ApiController
    {
        private WebTesteDB db = new WebTesteDB();

        //GET api/tabelaPaciente
        public IEnumerable<tabelaPaciente> GettabelaPacientes()
        {
            return db.tabelaPacientes.AsEnumerable();
        }

        //GET api/tabelaPaciente/5
        public tabelaPaciente GetTabelaPaciente(string cpf)
        {
            tabelaPaciente TabelaPaciente = db.tabelaPacientes.Find(cpf);

            if (TabelaPaciente == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return TabelaPaciente;
        }

        //PUT api/tabelaPaciente/5
        public HttpResponseMessage PuttabelaPaciente(string cpf, tabelaPaciente tbPaciente)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (cpf != tbPaciente.cpf)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(tbPaciente).State = EntityState.Modified;

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

        //POST api/tabelaPaciente
        public HttpResponseMessage PosttabelaPaciente(tabelaPaciente tbPaciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tabelaPacientes.Add(tbPaciente);
                    db.SaveChanges();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tbPaciente);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tbPaciente.cpf }));
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

        //DELETE api/tabelaPaciente/5
        public HttpResponseMessage DeletetabelaPaciente( string cpf)
        {
            tabelaPaciente tbPaciente = db.tabelaPacientes.Find(cpf);

            if (tbPaciente == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.tabelaPacientes.Remove(tbPaciente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tbPaciente);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
