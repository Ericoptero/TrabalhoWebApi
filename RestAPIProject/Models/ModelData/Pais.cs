namespace RestAPIProject.Models.ModelData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aula.Pais")]
    public partial class Pais
    {
        [Key]
        public long IdPais { get; set; }

        [Required]
        public string Nome { get; set; }

        [StringLength(2)]
        public string Abreviacao { get; set; }
    }
}
