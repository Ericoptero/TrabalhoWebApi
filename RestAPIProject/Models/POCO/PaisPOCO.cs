using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPIProject.Models.POCO
{
    public class PaisPOCO
    {
        public long IdPais { get; set; }

        public string Nome { get; set; }

        public string Abreviacao { get; set; }
    }
}