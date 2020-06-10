using System.Web.Http;
using WebActivatorEx;
using RestAPIProject;
using Swashbuckle.Application;
using System;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace RestAPIProject
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.Schemes(new[] { "http", "https" });

                    c.SingleApiVersion("v1", "Rest API Project")
                        .Description("Agrupamento de recursos disponíveis do Rest API Projects")
                        .TermsOfService("Termos de Serviço")
                        .Contact(contact => contact
                            .Name("Eric Nantes")
                            .Url("http://localhost/contact")
                            .Email("ericnantes18@gmail.com"))
                        .License(lcs => lcs
                            .Name("Licença do projeto")
                            .Url("http://localhost/license"));
                    c.PrettyPrint();
                    c.ApiKey("apiKey")
                        .Description("API Key para acessar a API de forma segura.")
                        .Name("Api-key")
                        .In("header");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("Rest API Project - 2020 - Swagger UI");
                    c.DocExpansion(DocExpansion.List);
                    c.EnableDiscoveryUrlSelector();
                });
        }

        private static string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\SwaggerDocs\RestAPIProject.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
