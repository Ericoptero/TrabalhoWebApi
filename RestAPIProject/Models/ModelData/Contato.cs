namespace RestAPIProject.Models.ModelData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aula.Contato")]
    public partial class Contato
    {
        [Key]
        public int IdContato { get; set; }

        [Required]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Fone { get; set; }

        public string Email { get; set; }
    }
}
