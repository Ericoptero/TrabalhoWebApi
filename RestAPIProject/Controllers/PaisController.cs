using RestAPIProject.Models.ModelData;
using RestAPIProject.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestAPIProject.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/localizacao")]
    public class PaisController : BaseAncestralController
    {
        /// <summary>
        /// 
        /// </summary>
        public PaisController() : base() 
        { }

        /// <summary>
        /// Obtem todos os registros da tabela.
        /// </summary>
        /// <remarks>
        /// Método da API equivalente a pesquisa do banco de dados SQL, semelhante a SELECT * FROM.
        /// </remarks>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("pais")]
        [ResponseType(typeof(List<PaisPOCO>))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<PaisPOCO> listaDePaises = Contexto.Paises
                    .Select(pais => new PaisPOCO
                    {
                        IdPais = pais.IdPais,
                        Nome = pais.Nome,
                        Abreviacao = pais.Abreviacao
                    })
                    .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, listaDePaises);
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
        [Route("pais/{id:int}")]
        [ResponseType(typeof(PaisPOCO))]
        [HttpGet]
        public HttpResponseMessage Get([FromUri] int id)
        {
            try
            {
                Pais pais = Contexto.Paises.Where(pa => pa.IdPais == id).SingleOrDefault();
                if (pais == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não foi encontrado");
                }
                PaisPOCO paisPOCO = new PaisPOCO()
                {
                    IdPais = pais.IdPais,
                    Nome = pais.Nome,
                    Abreviacao = pais.Abreviacao
                };
                return Request.CreateResponse(HttpStatusCode.OK, paisPOCO);
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
        /// <param name="poco">Conjunto de dados de Pais.</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("pais")]
        [ResponseType(typeof(PaisPOCO))]
        [HttpPost]
        public HttpResponseMessage Create([FromBody] PaisPOCO poco)
        {
            try
            {
                if (poco == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro inválido.");
                }
                Pais pais = new Pais
                {
                    IdPais = poco.IdPais,
                    Nome = poco.Nome,
                    Abreviacao = poco.Abreviacao
                };
                Contexto.Paises.Add(pais);
                Contexto.SaveChanges();
                poco.IdPais = pais.IdPais;
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
        /// <param name="poco">Conjunto de dados de Pais.</param>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("pais")]
        [ResponseType(typeof(PaisPOCO))]
        [HttpPut]
        public HttpResponseMessage Change([FromBody] PaisPOCO poco)
        {
            try
            {
                if (poco == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro inválido.");
                }
                if (Contexto.Paises.Where(pa => pa.IdPais == poco.IdPais).Count() == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não foi encontrado");
                }
                Pais pais = new Pais()
                {
                    IdPais = poco.IdPais,
                    Nome = poco.Nome,
                    Abreviacao = poco.Abreviacao
                };
                Contexto.Entry(pais).State = System.Data.Entity.EntityState.Modified;
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
        [Route("pais/{id:int}")]
        [ResponseType(typeof(PaisPOCO))]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            try
            {
                if (Contexto.Paises.Where(pa => pa.IdPais == id).Count() == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não foi encontrado");
                }
                Pais pais = Contexto.Paises.Find(id);
                PaisPOCO poco = new PaisPOCO()
                {
                    IdPais = pais.IdPais,
                    Nome = pais.Nome,
                    Abreviacao = pais.Abreviacao
                };
                Contexto.Entry(pais).State = System.Data.Entity.EntityState.Deleted;
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
