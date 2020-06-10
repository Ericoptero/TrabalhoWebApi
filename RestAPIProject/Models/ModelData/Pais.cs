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
    [Table("Aula.Pais")]
    public partial class Pais
    {

        /// <summary>
        /// 
        /// </summary>
        [Key]
        public long IdPais { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2)]
        public string Abreviacao { get; set; }
    }
}
