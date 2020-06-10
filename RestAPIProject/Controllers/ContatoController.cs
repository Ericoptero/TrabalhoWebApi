using RestAPIProject.Models.ModelData;
using RestAPIProject.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestAPIProject.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/suporte")]
    public class ContatoController : BaseAncestralController
    {
        /// <summary>
        /// 
        /// </summary>
        public ContatoController() : base()
        { }

        /// <summary>
        /// Obtem todos os registros da tabela.
        /// </summary>
        /// <remarks>
        /// Método da API equivalente a pesquisa do banco de dados SQL, semelhante a SELECT * FROM.
        /// </remarks>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("contato")]
        [ResponseType(typeof(List<ContatoPOCO>))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<ContatoPOCO> listaDeContatos = Contexto.Contatos
                    .Select(contato => new ContatoPOCO
                    {
                        IdContato = contato.IdContato,
                        Nome = contato.Nome,
                        Email = contato.Email,
                        Fone = contato.Fone
                    })
                    .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, listaDeContatos);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtém um registro da tabela, a partir da chave primária.
        /// </summary>
        /// <remarks>
        /// Método da API equivalente a pesquisa do banco de dados SQL, semelhante a SELECT FROM WHERE.
        /// </remarks>
        /// <param name="id">Chave Primária</param>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("contato/{id:int}")]
        [ResponseType(typeof(ContatoPOCO))]
        [HttpGet]
        public HttpResponseMessage Get([FromUri] int id)
        {
            try
            {
                Contato contato = Contexto.Contatos.Where(cont => cont.IdContato == id).SingleOrDefault();
                if (contato == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não foi encontrado");
                }
                ContatoPOCO contatoPOCO = new ContatoPOCO()
                {
                    IdContato = contato.IdContato,
                    Nome = contato.Nome,
                    Email = contato.Email,
                    Fone = contato.Fone
                };
                return Request.CreateResponse(HttpStatusCode.OK, contatoPOCO);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message, ex);
            }
        }

        /// <summary>
        /// Cria um registro na tabela, a partir da instância que representará o registro.
        /// </summary>
        /// <remarks>
        /// Método da API equivalente a pesquisa do banco de dados SQL, semelhante a INSERT INTO.
        /// </remarks>
        /// <param name="poco">Conjunto de dados de Contato.</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("contato")]
        [ResponseType(typeof(ContatoPOCO))]
        [HttpPost]
        public HttpResponseMessage Create([FromBody] ContatoPOCO poco)
        {
            try
            {
                if (poco == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro inválido.");
                }
                Contato contato = new Contato
                {
                    IdContato = poco.IdContato,
                    Nome = poco.Nome,
                    Email = poco.Email,
                    Fone = poco.Fone
                };
                Contexto.Contatos.Add(contato);
                Contexto.SaveChanges();
                poco.IdContato = contato.IdContato;
                return Request.CreateResponse(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message, ex);
            }
        }

        /// <summary>
        /// Altera um registro da tabela, a partir da instância que representa o registro.
        /// </summary>
        /// <remarks>
        /// Método da API equivalente a pesquisa do banco de dados SQL, semelhante a UPDATE.
        /// </remarks>
        /// <param name="poco">Conjunto de dados de Contato.</param>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("contato")]
        [ResponseType(typeof(ContatoPOCO))]
        [HttpPut]
        public HttpResponseMessage Change([FromBody] ContatoPOCO poco)
        {
            try
            {
                if (poco == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro inválido.");
                }
                if (Contexto.Contatos.Where(cont => cont.IdContato == poco.IdContato).Count() == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não foi encontrado");
                }
                Contato contato = new Contato()
                {
                    IdContato = poco.IdContato,
                    Nome = poco.Nome,
                    Email = poco.Email,
                    Fone = poco.Fone
                };
                Contexto.Entry(contato).State = System.Data.Entity.EntityState.Modified;
                Contexto.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message, ex);
            }
        }

        /// <summary>
        /// Exclui um registro da tabela, a partir da chave primária.
        /// </summary>
        /// <remarks>
        /// Método da API equivalente a pesquisa do banco de dados SQL, semelhante a DELETE.
        /// </remarks>
        /// <param name="id">Chave primária</param>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("contato/{id:int}")]
        [ResponseType(typeof(ContatoPOCO))]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            try
            {
                if (Contexto.Contatos.Where(cont => cont.IdContato == id).Count() == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não foi encontrado");
                }
                Contato contato = Contexto.Contatos.Find(id);
                ContatoPOCO poco = new ContatoPOCO()
                {
                    IdContato = contato.IdContato,
                    Nome = contato.Nome,
                    Email = contato.Email,
                    Fone = contato.Fone
                };
                Contexto.Entry(contato).State = System.Data.Entity.EntityState.Deleted;
                Contexto.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message, ex);
            }
        }
    }
}
