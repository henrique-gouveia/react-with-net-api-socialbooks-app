using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SocialBooks.Data.Repositories;
using SocialBooks.Models.Entities;
using SocialBooks.Models.Interfaces;

namespace SocialBooks.Api.Controllers
{
    public class AutorController : ApiController
    {
        private IRepository<Autor, int> autorRepository = new AutorRepository();

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, autorRepository.FindAll());
        }

        public Autor Get(int id)
        {
            Autor autor = autorRepository.FindOne(id);

            if (autor == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return autor;
        }

        public HttpResponseMessage Post([FromBody]Autor autor)
        {
            try
            {
                autorRepository.Insert(autor);
                var response = Request.CreateResponse<Autor>(HttpStatusCode.Created, autor);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/autor/" + autor.Id.ToString());
                return response;
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody]Autor autor)
        {
            try
            {
                autorRepository.Update(autor);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Autor autor = autorRepository.FindOne(id);
                autorRepository.Delete(autor);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
