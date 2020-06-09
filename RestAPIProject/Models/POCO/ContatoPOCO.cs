using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPIProject.Models.POCO
{
    public class ContatoPOCO
    {
        public int IdContato { get; set; }

        public string Nome { get; set; }

        public string Fone { get; set; }

        public string Email { get; set; }
    }
}