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
    [RoutePrefix("api/venda")]
    public class ProdutoController : BaseAncestralController
    {
        /// <summary>
        /// 
        /// </summary>
        public ProdutoController() : base() 
        { }

        /// <summary>
        /// Obtem todos os registros da tabela.
        /// </summary>
        /// <remarks>
        /// Método da API equivalente a pesquisa do banco de dados SQL, semelhante a SELECT * FROM.
        /// </remarks>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("produto")]
        [ResponseType(typeof(List<ProdutoPOCO>))]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<ProdutoPOCO> listaDeProdutos = Contexto.Produtos
                    .Select(produto => new ProdutoPOCO
                    {
                        IdProduto = produto.IdProduto,
                        Descricao = produto.Descricao,
                        Preco = produto.Preco,
                        QtdEstoque = produto.QtdEstoque
                    })
                    .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, listaDeProdutos);
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
        [Route("produto/{id:int}")]
        [ResponseType(typeof(ProdutoPOCO))]
        [HttpGet]
        public HttpResponseMessage Get([FromUri] int id)
        {
            try
            {
                Produto produto = Contexto.Produtos.Where(prod => prod.IdProduto == id).SingleOrDefault();
                if (produto == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não foi encontrado");
                }
                ProdutoPOCO produtoPOCO = new ProdutoPOCO()
                {
                    IdProduto = produto.IdProduto,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    QtdEstoque = produto.QtdEstoque
                };
                return Request.CreateResponse(HttpStatusCode.OK, produtoPOCO);
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
        /// <param name="poco">Conjunto de dados de Produto.</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("produto")]
        [ResponseType(typeof(ProdutoPOCO))]
        [HttpPost]
        public HttpResponseMessage Create([FromBody] ProdutoPOCO poco)
        {
            try
            {
                if (poco == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro inválido.");
                }
                Produto produto = new Produto
                {
                    IdProduto = poco.IdProduto,
                    Descricao = poco.Descricao,
                    Preco = poco.Preco,
                    QtdEstoque = poco.QtdEstoque
                };
                Contexto.Produtos.Add(produto);
                Contexto.SaveChanges();
                poco.IdProduto = produto.IdProduto;
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
        /// <param name="poco">Conjunto de dados de Produto.</param>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error.</response>
        /// <returns></returns>
        [Route("produto")]
        [ResponseType(typeof(ProdutoPOCO))]
        [HttpPut]
        public HttpResponseMessage Change([FromBody] ProdutoPOCO poco)
        {
            try
            {
                if (poco == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro inválido.");
                }
                if (Contexto.Produtos.Where(prod => prod.IdProduto == poco.IdProduto).Count() == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não foi encontrado");
                }
                Produto produto = new Produto()
                {
                    IdProduto = poco.IdProduto,
                    Descricao = poco.Descricao,
                    Preco = poco.Preco,
                    QtdEstoque = poco.QtdEstoque
                };
                Contexto.Entry(produto).State = System.Data.Entity.EntityState.Modified;
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
        [Route("produto/{id:int}")]
        [ResponseType(typeof(ProdutoPOCO))]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            try
            {
                if (Contexto.Produtos.Where(prod => prod.IdProduto == id).Count() == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não foi encontrado");
                }
                Produto produto = Contexto.Produtos.Find(id);
                ProdutoPOCO poco = new ProdutoPOCO()
                {
                    IdProduto = produto.IdProduto,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    QtdEstoque = produto.QtdEstoque
                };
                Contexto.Entry(produto).State = System.Data.Entity.EntityState.Deleted;
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
