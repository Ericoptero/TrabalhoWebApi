using RestAPIProject.Models.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPIProject.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseAncestralController : ApiController
    {
        private ModelProjectDB _contexto;

        /// <summary>
        /// 
        /// </summary>
        protected ModelProjectDB Contexto
        {
            get { return _contexto; }
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseAncestralController() : base()
        {
            _contexto = new ModelProjectDB();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
