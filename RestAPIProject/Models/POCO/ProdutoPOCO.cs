using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPIProject.Models.POCO
{
    public class ProdutoPOCO
    {
        public int IdProduto { get; set; }

        public string Descricao { get; set; }

        public int? QtdEstoque { get; set; }

        public decimal? Preco { get; set; }
    }
}