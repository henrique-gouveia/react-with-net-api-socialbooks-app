using System;
using System.Net;
using System.Web.Http;

using SocialBooks.Data.Repositories;
using SocialBooks.Models.Entities;
using SocialBooks.Models.Interfaces;

namespace SocialBooks.Api.Controllers
{
    [RoutePrefix("api/livros")]
    public class LivroController : ApiController
    {
        IRepository<Livro, int> livroRepository = new LivroRepository();

        [Route("")]
        [HttpGet]
        public IHttpActionResult Listar()
        {
            return Ok(livroRepository.FindAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Buscar(int id)
        {
            var livro = livroRepository.FindOne(id);
            if (livro == null)
                return NotFound();
            else
                return Ok(livro);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Inserir([FromBody] Livro livro)
        {
            try
            {
                livroRepository.Insert(livro);
                return Created<Livro>(
                    new Uri(Request.RequestUri, "/api/livros/" + livro.Id.ToString()),
                    livro);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult Atualizar(int id, [FromBody]Livro livro)
        {
            try
            {
                livro.Id = id;
                livroRepository.Update(livro);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Excluir(int id)
        {
            try
            {
                var livro = livroRepository.FindOne(id);
                livroRepository.Delete(livro);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
