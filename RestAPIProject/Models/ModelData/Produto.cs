namespace RestAPIProject.Models.ModelData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aula.Produto")]
    public partial class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public int? QtdEstoque { get; set; }

        public decimal? Preco { get; set; }
    }
}
