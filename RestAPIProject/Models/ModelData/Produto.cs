namespace RestAPIProject.Models.ModelData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 
    /// </summary>
    [Table("Aula.Produto")]
    public partial class Produto
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int IdProduto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(100)]
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
