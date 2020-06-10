using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPIProject.Models.POCO
{
    /// <summary>
    /// 
    /// </summary>
    public class ContatoPOCO
    {
        /// <summary>
        /// 
        /// </summary>
        public int IdContato { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Fone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
    }
}