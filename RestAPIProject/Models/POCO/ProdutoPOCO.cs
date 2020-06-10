using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPIProject.Models.POCO
{
    /// <summary>
    /// 
    /// </summary>
    public class ProdutoPOCO
    {
        /// <summary>
        /// 
        /// </summary>
        public int IdProduto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? QtdEstoque { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? Preco { get; set; }
    }
}