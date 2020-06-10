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
    [Table("Aula.Contato")]
    public partial class Contato
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int IdContato { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        public string Fone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
    }
}
